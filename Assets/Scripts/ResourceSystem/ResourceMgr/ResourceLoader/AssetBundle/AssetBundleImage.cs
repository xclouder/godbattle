/*************************************************************************
 *  FileName: AssetBundleImage.cs
 *  Author: xClouder
 *  Create Time: 07/18/2016
 *  Description:
 *
 *************************************************************************/


using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UniRx;

public class AssetBundleImage
{
	public enum ImageState{
		Unloaded,
		Loading,
		Loaded
	}

	public delegate void OnAssetBundleImageLoaded(AssetBundleImage img);
	public delegate void OnAssetBundleImageUnloaded(AssetBundleImage img);

	public event OnAssetBundleImageLoaded onLoaded;
	public event OnAssetBundleImageUnloaded onUnloaded;

	private string _name;
	public string Name { get {return _name;} }
	private int ReferenceCount { get;set; }
	public ImageState State {get;set;}

	public AssetBundle AssetBundle {get;set;}

	private HashSet<AssetBundleImage> _dependencies;
	public HashSet<AssetBundleImage> Dependencies { get { return _dependencies; }}

	public AssetBundleImage(string bundleName)
	{
		_name = bundleName;
		State = ImageState.Unloaded;	
		ReferenceCount = 0;
		AssetBundle = null;

		Debug.Log("==> create image: " + Name);
	}

	public void AddDependency(AssetBundleImage image)
	{
		if (_dependencies == null)
			_dependencies = new HashSet<AssetBundleImage>();

		image.onLoaded += OnDependencyImageLoaded;
		image.onUnloaded += OnDependencyImageUnloaded;

		_dependencies.Add(image);

		Debug.Log("==> add Dependency: " + Name + " -> " + image.Name);
	}

	public void IncreaseReferenceCount()
	{
		if (Dependencies != null && Dependencies.Count > 0)
		{
			foreach (var img in Dependencies)
			{
				img.IncreaseReferenceCount();
			}
		}

		ReferenceCount++;
	}

	public void DecreaseReferenceCount()
	{
		if (State != ImageState.Loaded)
		{
			throw new System.InvalidOperationException("you should call decreasereReferenceCount after image loaded");
		}

		if (_dependencies != null && _dependencies.Count > 0)
		{
			foreach (var img in _dependencies)
			{
				img.DecreaseReferenceCount();
			}
		}
		
		ReferenceCount--;

		if (ReferenceCount == 0)
			UnloadInternal();
	}

	/// <summary>
	/// 加载完成需要：assetBundle自己加载完成，Dependencies全部加载完成
	/// </summary>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	public void LoadAsync()
	{
		if (!(State == ImageState.Unloaded))
		{
			Debug.LogWarning("Image is loading or loaded.");
			return;
		}

		Debug.Log("==> start load image:" + Name);

		//load dependencies first
		if (_dependencies != null && _dependencies.Count > 0)
		{
			foreach (var img in _dependencies)
			{
				if (img.State == ImageState.Unloaded)
					img.LoadAsync();

			}
		}

		var observable = Observable.FromCoroutine<AssetBundle>((observer, cancellationToken) => LoadBundleInternal(Name, observer, cancellationToken));
		observable.Subscribe(bundle => {

			AssetBundle = bundle;

			CheckAndNotifyIfAllCompleted();

		});
	}

	public string BundlePath { get;set; }
	private IEnumerator LoadBundleInternal<T>(string bundleName, IObserver<T> observer, CancellationToken cancellationToken) where T : UnityEngine.Object
	{
		var req = AssetBundle.LoadFromFileAsync(BundlePath);

		while (!req.isDone)
		{
			yield return null;
		}

		if (!cancellationToken.IsCancellationRequested)
		{
			observer.OnNext(req.assetBundle as T);
			observer.OnCompleted();
		}

	}

	private void CheckAndNotifyIfAllCompleted()
	{
		if (this.AssetBundle != null)
		{
			if (_dependencies != null && _dependencies.Count > 0)
			{
				foreach (var img in _dependencies)
				{
					if (img.State != ImageState.Loaded)
					{
						return;
					}
				}
			}

			State = ImageState.Loaded;

			if (onLoaded != null)
				onLoaded(this);
		}
	}

	/// <summary>
    /// UnloadInternal只能在referenceCount==0的时候自动调用
    /// </summary>
	private void UnloadInternal()
	{
		Debug.Log("==> unload image:" + Name);
		Debug.Assert(State == ImageState.Loaded);
		Debug.Assert(ReferenceCount == 0);
		
		AssetBundle.Unload(false);
	}

	public AssetBundleRequest LoadAssetAsync(string name)
	{
		return AssetBundle.LoadAssetAsync(name);
	}

	#region Dependency Image Event Listener
	private void OnDependencyImageLoaded(AssetBundleImage img)
	{
		CheckAndNotifyIfAllCompleted();
	}

	private void OnDependencyImageUnloaded(AssetBundleImage img)
	{
		throw new System.InvalidOperationException("that's impossible!");
	}
	#endregion
	
}