/*************************************************************************
 *  FileName: ResourceLoader.cs
 *  Author: xClouder
 *  Create Time: 06/22/2016
 *  Description:
 *
 *************************************************************************/

using UnityEngine;
using System.Collections;
using UniRx;

public class ResourceLoader : IResourceLoader
{
	public void LoadAsync<T>(string name, System.Action<T> onComplete) where T : UnityEngine.Object
	{
		var observable = Observable.FromCoroutine<T>((observer, cancellationToken) => LoadInternal(name, observer, cancellationToken));
		observable.Subscribe(res => {

			if (onComplete != null)
				onComplete(res);

		});
	}

	private IEnumerator LoadInternal<T>(string name, IObserver<T> observer, CancellationToken cancellationToken) where T : UnityEngine.Object
	{
		var asyncOp = Resources.LoadAsync(name);

		while (!asyncOp.isDone && !cancellationToken.IsCancellationRequested)
		{
			yield return null;
		}

		if (!cancellationToken.IsCancellationRequested)
		{
			observer.OnNext(asyncOp.asset as T); // push 100%
			observer.OnCompleted();
		}
	}


}