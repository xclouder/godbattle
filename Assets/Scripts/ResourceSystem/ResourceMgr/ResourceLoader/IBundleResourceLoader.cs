/*************************************************************************
 *  FileName: IBundleResourceLoader.cs
 *  Author: xClouder
 *  Create Time: #CreateTime#
 *  Description:
 *
 *************************************************************************/

public interface IBundleResourceLoader
{
	void LoadAsync<T>(string bundleName, string assetName, System.Action<T> onComplete) where T : UnityEngine.Object;
}