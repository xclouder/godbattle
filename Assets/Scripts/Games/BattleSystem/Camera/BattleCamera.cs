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
	private Vector3 screenCenterToCameraDir;
	private Camera cam;
	
	// Use this for initialization
	void Start () {
		tr = transform;
		cam = GetComponent<Camera>();
		
		DoInit();
	}

	private void DoInit()
	{
		currentViewLeftBottomPos = farViewLeftBottomPos;
		currentViewRightTopPos = farViewRightTopPos;
		
		var center = new Vector2(Screen.width / 2, Screen.height / 2);
		var ray = cam.ScreenPointToRay(center);
		screenCenterToCameraDir = -ray.direction;
	}
	
	// Update is called once per frame
	void LateUpdate () {

		if (Input.GetKey(KeyCode.Space))
		{
			var entity = GameObject.Find("Entity");
			if (entity == null)
			{
				Debug.LogError("no entity found");
				return;
			}
			var to = entity.transform.position;

			Vector3 camPos = Vector3.zero;
			if (LocateToPosition(to, out camPos))
			{
				tr.position = camPos;
			}

			return;
		}

		var scrollWheel = Input.GetAxis("Mouse ScrollWheel");
		float originY = tr.position.y;
		float newY = originY;
		if (scrollWheel != 0)
		{
			if (Mathf.Approximately(originY, nearViewLeftBottomPos.y) && scrollWheel < 0)
			{
				//ignore adjuge
			}
			else if (Mathf.Approximately(originY, farViewLeftBottomPos.y) && scrollWheel > 0)
			{
				//ignore adjuge
			}
			else
			{
				var delta = scrollWheel * viewResizeSpeed * Time.deltaTime;
				var deltaPos = screenCenterToCameraDir * delta;
				
				newY = originY + deltaPos.y;
				newY = Mathf.Clamp(newY, nearViewLeftBottomPos.y, farViewLeftBottomPos.y);

				var correctDeltaY = newY - originY;
				deltaPos = correctDeltaY / deltaPos.y * deltaPos;

				transform.position += deltaPos;
				GetViewCornorPosition(newY, out currentViewLeftBottomPos, out currentViewRightTopPos);
			}
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

		transform.position = newPos;
	}
	
	public bool LocateToPosition(Vector3 worldPos, out Vector3 toPosition)
	{
		/**
		* 计算从worldPos出发，方向为screenCenterToCameraDir的射线，y=currentViewLeftBottomPos.y时的点，这个点就是相机的位置。
		* 设目标位置A(x, m, z), m已知为currentViewLeftBottomPos.y
		* 射线Origin：A(ax,ay,az) -- worldPos, dir:Dir (dx,dy,dz) -- screenCenterToCameraDir
		* 
		* 那么有下面的方程：
		* x - ax = k * dx
		* m - ay = k * dy
		* z - az = k * dz
		*
		* 可得出: (dy != 0时)
		* k = (m - ay)/dy
		* x = k*dx + ax
		* z = k*dz + az
		*/
		
		if (screenCenterToCameraDir.y == 0f)
		{
			toPosition = Vector3.zero;
			return false;
		}
		
		var m = currentViewLeftBottomPos.y;
		var ax = worldPos.x;
		var ay = worldPos.y;
		var az = worldPos.z;
		
		var dx = screenCenterToCameraDir.x;
		var dy = screenCenterToCameraDir.y;
		var dz = screenCenterToCameraDir.z;
		
		
		var k = (m - ay) / dy;
		var x = k*dx + ax;
		var z = k*dz + az;
		
		toPosition = new Vector3(x, m, z);
		return true;
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
