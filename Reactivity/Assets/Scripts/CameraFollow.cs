using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Level_1Game_Controller l1_GameControl;
	//seguimiento de la camara a personaje
	public GameObject follow;
	public Vector2 minCamPos, maxCamPos;
	public float maxspeed = 0.1f;

	//efecto de suavizado a la camara
	public float suavizadoTime;

	private Vector2 velocityCam;
	private bool movingCam;



	void Start () {
		
	}


	void FixedUpdate () {
		//siguiendo posision de personaje
		float posX = Mathf.SmoothDamp(transform.position.x,
			follow.transform.position.x, ref velocityCam.x, suavizadoTime);
		float posY =  Mathf.SmoothDamp(transform.position.y,
			follow.transform.position.y, ref velocityCam.y, suavizadoTime);
		
		//posision de camara en funcion de personaje
		transform.position = new Vector3 (
			Mathf.Clamp(posX,minCamPos.x, maxCamPos.x),
			Mathf.Clamp(posY,minCamPos.y,maxCamPos.y),
			transform.position.z);


		if((transform.position.x == minCamPos.x) || (transform.position.x == maxCamPos.x )){
			velocityCam.x = 0f;

		}
		if(velocityCam.x == Mathf.Clamp(velocityCam.x,-maxspeed,maxspeed) ){
			movingCam = false;
		} else movingCam = true;

		if(movingCam){
			
		}//llamando a paralax
		if (velocityCam.x < -maxspeed) {
			l1_GameControl.ParallaxGoBack ();

		} else if (velocityCam.x > maxspeed){
			l1_GameControl.ParallaxGoFoward ();
		}

	}

}
