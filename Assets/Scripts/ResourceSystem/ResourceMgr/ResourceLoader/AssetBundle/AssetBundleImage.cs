/*************************************************************************
 *  FileName: AssetBundleImage.cs
 *  Author: xClouder
 *  Create Time: 07/18/2016
 *  Description:
 *
 *************************************************************************/

using UnityEngine;
using System.Collections.Generic;

public class AssetBundleImage
{
	public enum ImageState{
		Unloaded,
		Loading,
		Loaded
	}

	public delegate void OnAssetBundleImageLoaded(AssetBundleImage img);
	public delegate void OnAssetBundleImageUnloaded(AssetBundleImage img);

	private int ReferenceCount { get;set; }
	public ImageState State {get;set;}

	public AssetBundle AssetBundle {get;set;}

	private HashSet<AssetBundleImage> _dependencies;
	public HashSet<AssetBundleImage> Dependencies { get { return _dependencies; }}

	public AssetBundleImage(AssetBundle bundle)
	{
		State = ImageState.Unloaded;	
		ReferenceCount = 0;
		AssetBundle = bundle;
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
			UnLoad();
	}

	public void LoadAsync()
	{
		//load dependencies first
		if (_dependencies != null && _dependencies.Count > 0)
		{

		}
	}

	/// <summary>
    /// Unload只能在referenceCount==0的时候自动调用
    /// </summary>
	private void UnLoad()
	{
		Debug.Assert(State == ImageState.Loaded);
		Debug.Assert(ReferenceCount == 0);
		
		AssetBundle.Unload(false);
	}

	public AssetBundleRequest LoadAssetAsync(string name)
	{
		return AssetBundle.LoadAssetAsync(name);
	}

	
}