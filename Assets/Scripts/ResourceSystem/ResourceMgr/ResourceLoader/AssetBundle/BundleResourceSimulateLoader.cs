/*************************************************************************
 *  FileName: BundleResourceSimulateLoader.cs
 *  Author: xClouder
 *  Create Time: 07/25/2016
 *  Description:
 *
 *************************************************************************/
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Collections;
using UniRx;

public class BundleResourceSimulateLoader : IBundleResourceLoader
{
	public IEnumerator InitializeAsync()
	{
		yield break;
	}

	public T Load<T>(string bundleName, string assetName) where T : UnityEngine.Object
	{
		Debug.Log ("[Simulate Load] bundle:" + bundleName + ", asset:" + assetName);

		return _Get<T>(bundleName, assetName);
	}

	public void LoadAsync<T>(string bundleName, string assetName, System.Action<T> onComplete) where T : UnityEngine.Object
	{
		Debug.Log ("load in simulate mode => bundle:" + bundleName + ", asset:" + assetName);
		var observable = Observable.FromCoroutine<T>((observer, cancellationToken) => 
			_GetAsync<T>(bundleName, assetName, observer, cancellationToken)
		);

		observable.Subscribe(res => {
			if (onComplete != null)
				onComplete(res);
		});
	}

	private IEnumerator _GetAsync<T>(string bundleName, string assetName, IObserver<T> observer, CancellationToken cancellationToken, float delay = 0.02f) where T : UnityEngine.Object
	{
		yield return new WaitForSeconds(delay);

		var obj = _Get<T>(bundleName, assetName);

		if (!cancellationToken.IsCancellationRequested)
		{
            observer.OnNext(obj);
			observer.OnCompleted();
        }
	}

	private T _Get<T>(string bundleName, string assetName) where T : UnityEngine.Object
	{
		#if UNITY_EDITOR
		
		string[] assetPaths = AssetDatabase.GetAssetPathsFromAssetBundleAndAssetName(bundleName, assetName);
		if (assetPaths.Length == 0)
		{
			Debug.LogError("There is no asset with name \"" + assetName + "\" in " + bundleName);
			return null;
		}

		Object target = AssetDatabase.LoadMainAssetAtPath(assetPaths[0]);
		return target as T;
		
		#else

		throw new System.Exception("simulate loader can only work in editor mode");
		
		#endif

	}
}