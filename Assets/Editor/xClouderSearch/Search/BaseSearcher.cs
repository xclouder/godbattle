using UnityEngine;
using System.Collections;

public abstract class BaseSearcher {

	/// <summary>
	/// Search the specified key.
	/// Returns the path list
	/// </summary>
	/// <param name="key">Key.</param>
	public abstract string[] Search(string key);

}
