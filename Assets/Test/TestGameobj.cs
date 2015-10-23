using UnityEngine;
using System.Collections;

public class TestGameobj : MonoBehaviour {

	private static GameObject g;

	// Use this for initialization
	void Start () {
		Debug.Log(g.name);

		if (g == null)
		{
			Debug.Log("give a gameObject");
			g = gameObject;
		}
		else
		{
			Debug.Log("gameObject not null");
		}
	}
	

	public void T()
	{
		Debug.Log("g is :" + g.name);
	}

	public void Reload()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

}
