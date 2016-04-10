using UnityEngine;
using System.Collections;

public class Utils {
	#region UI Related
	public static void SetRectTransformSize(RectTransform trans, Vector2 newSize)
	{
		Vector2 oldSize = trans.rect.size;
		Vector2 deltaSize = newSize - oldSize;
		trans.offsetMin = trans.offsetMin - new Vector2(deltaSize.x * trans.pivot.x, deltaSize.y * trans.pivot.y);
		trans.offsetMax = trans.offsetMax + new Vector2(deltaSize.x * (1f - trans.pivot.x), deltaSize.y * (1f - trans.pivot.y));
	}
	#endregion

	#region 3D Related
	public static bool GetPointInTerrain(float x, float z, out Vector3 point, string terrainLayerName = "Terrian")
	{
		//Mogo.Util.LoggerHelper.Debug("GetPointInTerrain");
		RaycastHit hit;
		//var flag = Physics.Raycast(new Vector3(x, 500, z), Vector3.down, out hit,1000, (int)LayerMask.Terrain);
		var flag = Physics.Linecast(new Vector3(x, 1000, z), new Vector3(x, -1000, z), out hit, LayerMask.GetMask(new string[]{terrainLayerName}));
		if (flag)
		{
			//Mogo.Util.LoggerHelper.Debug("hit.point: " + hit.point);
			point = new Vector3(hit.point.x, hit.point.y + 0.2f, hit.point.z);
			return true;
		}
		else
		{
			point = new Vector3(x, 50, z);
			return false;
		}
		
	}

	public static float GetDistanceIn2D(Vector3 p1, Vector3 p2)
	{
		var delta = p2 - p1;
		return Mathf.Sqrt(delta.x * delta.x + delta.z * delta.z);
	}

	#endregion
}
