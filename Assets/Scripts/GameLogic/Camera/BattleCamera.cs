using UnityEngine;
using System.Collections;

public class BattleCamera : MonoBehaviour {

	public Vector3 nearViewLeftBottomPos;
	public Vector3 nearViewRightTopPos;
	public Vector3 farViewLeftBottomPos;
	public Vector3 farViewRightTopPos;

	public float moveSpeed = 3f;
	public float sensitiveSize = 20f;

	public float viewResizeSpeed = 1f;
	private Vector3 currentViewLeftBottomPos;
	private Vector3 currentViewRightTopPos;
	private Transform tr;

	// Use this for initialization
	void Start () {
		tr = transform;
		DoInit();
	}

	private void DoInit()
	{
		currentViewLeftBottomPos = farViewLeftBottomPos;
		currentViewRightTopPos = farViewRightTopPos;
	}
	
	// Update is called once per frame

	void LateUpdate () {

		var scrollWheel = Input.GetAxis("Mouse ScrollWheel");
		float newY = tr.position.y;
		if (scrollWheel != 0)
		{
			newY = tr.position.y + scrollWheel * viewResizeSpeed * Time.deltaTime;
			newY = Mathf.Clamp(newY, nearViewLeftBottomPos.y, farViewLeftBottomPos.y);

			GetViewCornorPosition(newY, out currentViewLeftBottomPos, out currentViewRightTopPos);
		}


		var mousePos = Input.mousePosition;
		var cameraMove = CalculateCameraMovement(mousePos);

		var newPos = transform.position + cameraMove;
		if (newPos.x < currentViewLeftBottomPos.x)
		{
			newPos.x = currentViewLeftBottomPos.x;
		}

		if (newPos.x > currentViewRightTopPos.x)
		{
			newPos.x = currentViewRightTopPos.x;
		}

		if (newPos.z < currentViewLeftBottomPos.z)
		{
			newPos.z = currentViewLeftBottomPos.z;
		}

		if (newPos.z > currentViewRightTopPos.z)
		{
			newPos.z = currentViewRightTopPos.z;
		}

		newPos.y = newY;
		transform.position = newPos;
	}

	private void GetViewCornorPosition(float y, out Vector3 leftBottomPos, out Vector3 rightTopPos)
	{
		var percent = Mathf.InverseLerp(nearViewLeftBottomPos.y, farViewLeftBottomPos.y, y);
		leftBottomPos = Vector3.Lerp(nearViewLeftBottomPos, farViewLeftBottomPos, percent);
		rightTopPos = Vector3.Lerp(nearViewRightTopPos, farViewRightTopPos, percent);
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
