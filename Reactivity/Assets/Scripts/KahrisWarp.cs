using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KahrisWarp : MonoBehaviour {

	public animsController animacion;


	//detectando lo que choca con este trigger
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "warp") {
			animacion.Animando ();

		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "warp") {
			animacion.NoAnimando ();
		}
	}

}
