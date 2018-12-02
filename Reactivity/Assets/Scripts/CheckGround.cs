using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour {

	private Player_Controller player;
	private Rigidbody2D rbKahris;

	// Use this for initialization
	void Start () {
		player = GetComponent<Player_Controller> ();
		rbKahris = GetComponent<Rigidbody2D> ();
	}

	void OnCollisionEnter2D(Collision2D primerChoque){
		//si choco con un tag: plat movil, velocidad = 0
		if(primerChoque.gameObject.tag == "movil"){
			rbKahris.velocity = new Vector3 (0f,0f,0f);
			player.transform.parent = primerChoque.transform;
			player.grounded = true;
		}

	}

	// Update is called once per frame
	void OnCollisionStay2D(Collision2D chocando){
		if(chocando.gameObject.tag == "suelo"){
			player.grounded = true;
		}
		if(chocando.gameObject.tag == "movil"){
			player.transform.parent = chocando.transform;
			player.grounded = true;
		}
	}

	void OnCollisionExit2D(Collision2D chocando){
		if(chocando.gameObject.tag == "suelo"){
			player.grounded = false;
		}
		if(chocando.gameObject.tag == "movil"){
			player.transform.parent = null;
			player.grounded = false;
		}
	}
}
