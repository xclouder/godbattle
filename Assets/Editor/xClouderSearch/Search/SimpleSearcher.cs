using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Linq;

public class SimpleSearcher : BaseSearcher {

	private const string TYPE_INDICATOR = ":";

	public override string[] Search(string key)
	{
		var index = key.IndexOf(TYPE_INDICATOR);

		string searchText = null;
		string typeText = null;
		if (index >= 0)
		{
			searchText = key.Substring(0, index);
			if (index < key.Length - 1)
			{
				typeText = key.Substring(index + 1);
			}
		}
		else
		{
			searchText = key;
		}

//		Debug.Log("searchText:" + searchText + ", type:" + typeText);

		var list = AssetDatabase.FindAssets(searchText);
		var pathList = new string[list.Length];

		for (int i = 0; i < list.Length; i++)
		{
			var guid = list[i];
			var p = AssetDatabase.GUIDToAssetPath(guid);
			pathList[i] = p;
		}

		Debug.LogWarning("len:"+pathList.Length);
		if (!string.IsNullOrEmpty(typeText))
		{
			Debug.Log("aaa");
			pathList = pathList.Where(p => p.Substring(p.LastIndexOf('.') + 1).StartsWith(typeText)).ToArray();
		}

		return pathList;

	}

}
