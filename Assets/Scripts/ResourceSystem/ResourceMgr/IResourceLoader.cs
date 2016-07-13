/*************************************************************************
 *  FileName: IResourceLoader.cs
 *  Author: xClouder
 *  Create Time: 06/22/2016
 *  Description:
 *
 *************************************************************************/

using UnityEngine;
using System.Collections;

public interface IResourceLoader
{
	void LoadAsync<T>(string name, System.Action<T> onComplete) where T : UnityEngine.Object;
}