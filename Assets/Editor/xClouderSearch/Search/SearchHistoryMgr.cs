using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SearchHistoryMgr {

	private const int MAX_HISTORY_ITEMS = 10;

	private LinkedList<string> historyList;

	public SearchHistoryMgr()
	{
		historyList = new LinkedList<string>();
	}

	//for better experience, we should use SearchItem model, which using path, guid etc.
	public void AddToOrUpdateHistory(string path)
	{
		if (historyList.Contains(path))
		{
			historyList.Remove(path);
		}

		historyList.AddFirst(path);

		if (historyList.Count > MAX_HISTORY_ITEMS)
			historyList.RemoveLast();

	}

	public void Clear()
	{
		historyList.Clear();
	}

	public string[] GetHistory()
	{
		var arr = new string[historyList.Count];
		historyList.CopyTo(arr, 0);

//		Debug.Log(arr);
		return arr;
	}

}
