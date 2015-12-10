using UnityEngine;
using System.Collections;

public class BattleCamera : MonoBehaviour {

	public Vector3 nearViewLeftBottomPos;
	public Vector3 nearViewRightTopPos;
	public Vector3 farViewLeftBottomPos;
	public Vector3 farViewRightTopPos;

	public float moveSpeed = 3f;
	public float sensitiveSize = 20f;
	private Camera camera;

//	public Vector3 cameraLeftBottomLimit = new Vector3();
//	public Vector3 cameraRightTopLimit = new Vector3();

	// Use this for initialization
	void Start () {
		camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void LateUpdate () {

		var mousePos = Input.mousePosition;
		var cameraMove = CalculateCameraMovement(mousePos);

		var newPos = transform.position + cameraMove;
		if (newPos.x < farViewLeftBottomPos.x)
		{
			newPos.x = farViewLeftBottomPos.x;
		}

		if (newPos.x > farViewRightTopPos.x)
		{
			newPos.x = farViewRightTopPos.x;
		}

		if (newPos.z < farViewLeftBottomPos.z)
		{
			newPos.z = farViewLeftBottomPos.z;
		}

		if (newPos.z > farViewRightTopPos.z)
		{
			newPos.z = farViewRightTopPos.z;
		}

		transform.position = newPos;
	}

	private Vector3 CalculateCameraMovement(Vector2 mousePos )
	{
		var scrWidth = Screen.width;
		var scrHeight = Screen.height;
		
//		Debug.Log("screen width:" + scrWidth + ", screen height:" + scrHeight);
//		Debug.Log("mousePos:" + mousePos);
		
		float moveDeltaX = 0f;
		float moveDeltaY = 0f;
		
		if (mousePos.x < sensitiveSize)
		{
			moveDeltaX -= moveSpeed * Time.deltaTime;
		}
		
		if (mousePos.x > (scrWidth - sensitiveSize))
		{
			moveDeltaX += moveSpeed * Time.deltaTime;
		}
		
		if (mousePos.y < sensitiveSize)
		{
			moveDeltaY -= moveSpeed * Time.deltaTime;
		}
		
		if (mousePos.y > (scrHeight - sensitiveSize))
		{
			moveDeltaY += moveSpeed * Time.deltaTime;
		}

		return new Vector3(moveDeltaX, 0f, moveDeltaY);
	}
}
