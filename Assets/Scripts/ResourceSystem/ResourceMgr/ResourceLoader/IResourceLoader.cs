/*************************************************************************
 *  FileName: IResourceLoader.cs
 *  Author: xClouder
 *  Create Time: 06/22/2016
 *  Description:
 *
 *************************************************************************/

public interface IResourceLoader
{
	void LoadAsync<T>(string name, System.Action<T> onComplete) where T : UnityEngine.Object;

	T Load<T>(string name) where T : UnityEngine.Object;
}