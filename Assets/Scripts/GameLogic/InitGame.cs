using UnityEngine;
using System.Collections;

public class InitGame : MonoBehaviour {

	public bool isAutoCreatedInEditorRuntime = false;

	void Awake()
	{
		Init();
	}
	
	public void Init() {
		
		CloudApplication.Initialize(gameObject);
//		Destroy(this);
	}

}
