using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {	
	void Start ()
	{
		Messenger.AddListener("start game", StartGame);
	}
	
	void StartGame()
	{
		Debug.Log("StartGame called in" + gameObject);  //This is the line that would throw an exception
	}
	
	public void StartGameButtonPressed()
	{
		Messenger.Broadcast("start game");
	}
}