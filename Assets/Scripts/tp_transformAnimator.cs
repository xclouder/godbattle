using UnityEngine;
using System.Collections;
public enum aPlayMode
{
	Default,
	PingPong,
}
[System.Serializable]
public class VECTOR3{
	public bool animate=false;
	public aPlayMode playMode;
	public float valMin=0.0f;
	public float valMax=90.0f;
	public float speed=5.0f;
}
[System.Serializable]
public class TRANSFORM{
	public VECTOR3 x;
	public VECTOR3 y;
	public VECTOR3 z;

}

[AddComponentMenu("ArtCode/Transform Animater")]
public class tp_transformAnimator : MonoBehaviour {
	public TRANSFORM positionAni;
	public TRANSFORM rotationAni;
	public TRANSFORM scaleAni;

	float posXval;
	float posYval;
	float posZval;
	float rotXval;
	float rotYval;
	float rotZval;
	float scaleXval;
	float scaleYval;
	float scaleZval;
	// Use this for initialization
	void Start () {
		Transform selfTransform=GetComponent<Transform>();
		if(positionAni.x.animate|positionAni.y.animate|positionAni.z.animate){
			posXval=selfTransform.localPosition.x;
			posYval=selfTransform.localPosition.y;
			posZval=selfTransform.localPosition.z;
		}
		if(rotationAni.x.animate|rotationAni.y.animate|rotationAni.z.animate){		
			rotXval=selfTransform.eulerAngles.x;
			rotYval=selfTransform.eulerAngles.y;
			rotZval=selfTransform.eulerAngles.z;
		}
		if(scaleAni.x.animate|scaleAni.y.animate|scaleAni.z.animate){
			scaleXval=selfTransform.localScale.x;
			scaleYval=selfTransform.localScale.y;
			scaleZval=selfTransform.localScale.z;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		Transform selfTransform=GetComponent<Transform>();	
		if(positionAni.x.animate){
			if(positionAni.x.playMode==aPlayMode.PingPong){
				posXval=(Mathf.Sin(Time.time*positionAni.x.speed)+1)*(positionAni.x.valMax-positionAni.x.valMin)/2+positionAni.x.valMin;
			}else{
				posXval+=Time.deltaTime*positionAni.x.speed;
			}
		}
		if(positionAni.y.animate){
			if(positionAni.y.playMode==aPlayMode.PingPong){
				posYval=(Mathf.Sin(Time.time*positionAni.y.speed)+1)*(positionAni.y.valMax-positionAni.y.valMin)/2+positionAni.y.valMin;
			}else{
				posYval+=Time.deltaTime*positionAni.y.speed;
			}
		}
		if(positionAni.z.animate){
			if(positionAni.z.playMode==aPlayMode.PingPong){
				posZval=(Mathf.Sin(Time.time*positionAni.z.speed)+1)*(positionAni.z.valMax-positionAni.z.valMin)/2+positionAni.z.valMin;
			}else{
				posZval+=Time.deltaTime*positionAni.z.speed;
			}
		}

		if(positionAni.x.animate|positionAni.y.animate|positionAni.z.animate){
			selfTransform.localPosition=new Vector3(posXval,posYval,posZval);
		}
		
		
		
		
//////////////////////////////////////////////////////////////////////////////		
		if(rotationAni.x.animate){
			if(rotationAni.x.playMode==aPlayMode.PingPong){
				rotXval=(Mathf.Sin(Time.time*rotationAni.x.speed)+1)*(rotationAni.x.valMax-rotationAni.x.valMin)/2+rotationAni.x.valMin;
			}else{
				rotXval+=(Time.deltaTime*rotationAni.x.speed*50.0f);
				rotXval%=360.0f;
			}
		}
		if(rotationAni.y.animate){
			if(rotationAni.y.playMode==aPlayMode.PingPong){
				rotYval=(Mathf.Sin(Time.time*rotationAni.y.speed)+1)*(rotationAni.y.valMax-rotationAni.y.valMin)/2+rotationAni.y.valMin;
			}else{
				rotYval+=(Time.deltaTime*rotationAni.y.speed*50.0f);
				rotYval%=360.0f;
			}
		}
		if(rotationAni.z.animate){
			if(rotationAni.z.playMode==aPlayMode.PingPong){
				rotZval=(Mathf.Sin(Time.time*rotationAni.z.speed)+1)*(rotationAni.z.valMax-rotationAni.z.valMin)/2+rotationAni.z.valMin;
			}else{
				rotZval+=(Time.deltaTime*rotationAni.z.speed*50.0f);
				rotZval%=360.0f;
			}
		}

		if(rotationAni.x.animate|rotationAni.y.animate|rotationAni.z.animate){
			selfTransform.eulerAngles=new Vector3(rotXval,rotYval,rotZval);
		}
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////		
		if(scaleAni.x.animate){
			if(scaleAni.x.playMode==aPlayMode.PingPong){
				scaleXval=(Mathf.Sin(Time.time*scaleAni.x.speed)+1)*(scaleAni.x.valMax-scaleAni.x.valMin)/2+scaleAni.x.valMin;
			}else{
				scaleXval+=Time.deltaTime*scaleAni.x.speed;
			}
		}
		if(scaleAni.y.animate){
			if(scaleAni.y.playMode==aPlayMode.PingPong){
				scaleYval=(Mathf.Sin(Time.time*scaleAni.y.speed)+1)*(scaleAni.y.valMax-scaleAni.y.valMin)/2+scaleAni.y.valMin;
			}else{
				scaleYval+=Time.deltaTime*scaleAni.y.speed;
			}
		}
		if(scaleAni.z.animate){
			if(scaleAni.z.playMode==aPlayMode.PingPong){
				scaleZval=(Mathf.Sin(Time.time*scaleAni.z.speed)+1)*(scaleAni.z.valMax-scaleAni.z.valMin)/2+scaleAni.z.valMin;
			}else{
				scaleZval+=Time.deltaTime*scaleAni.z.speed;
			}
		}

		if(scaleAni.x.animate|scaleAni.y.animate|scaleAni.z.animate){
			selfTransform.localScale=new Vector3(scaleXval,scaleYval,scaleZval);
		}
	}
}
