using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour {

	private Player_Controller player;
	// Use this for initialization
	void Start () {
		player = GetComponent<Player_Controller> ();

	}
	
	// Update is called once per frame
	void OnCollisionStay2D(Collision2D chocando){
		if(chocando.gameObject.tag == "suelo"){
			player.grounded = true;
		}

	}

	void OnCollisionExit2D(Collision2D chocando){
		if(chocando.gameObject.tag == "suelo"){
			player.grounded = false;
		}
	}
}
