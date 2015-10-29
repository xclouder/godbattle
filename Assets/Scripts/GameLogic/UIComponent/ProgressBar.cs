using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour {

	public RectTransform bar;

	[Range(0, 1)]
	public float value = 0;

	private float maxWidth;
	private float height;
	void Start()
	{
		var parentRect = bar.parent as RectTransform;
		var size = parentRect.rect.size;
		maxWidth = size.x;
		height = size.y;
	}

	void Update()
	{
		Utils.SetRectTransformSize(bar, new Vector2(maxWidth * value, height));
	}

}
