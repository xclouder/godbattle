/*************************************************************************
 *  FileName: IBundleResourceLoader.cs
 *  Author: xClouder
 *  Create Time: #CreateTime#
 *  Description:
 *
 *************************************************************************/
using System.Collections;

public interface IBundleResourceLoader
{
	IEnumerator InitializeAsync();
	void LoadAsync<T>(string bundleName, string assetName, System.Action<T> onComplete) where T : UnityEngine.Object;
	T Load<T>(string bundleName, string assetName) where T : UnityEngine.Object;
}