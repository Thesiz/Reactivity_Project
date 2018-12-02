using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	//TODO:poner condiciones si se mueve la camara hacer paralax

	//seguimiento de la camara a personaje
	public GameObject follow;

	//desde donde hasta donde irá mi camara
	public Vector2 minCamPos, maxCamPos;

	//efecto de suavizado a la camara
	public float suavizadoTime;



	private Vector2 velocityCam;


	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
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
	}
}
