using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WarpController : MonoBehaviour {

	public Level_Changer lv_change;
	public HudController hudControl;

	public GameObject target;
	public Collider2D kahris;

	public GameObject targetMap;


	GameObject mapa;


	private bool tocandoWarp;

		void Awake(){
		GetComponent<SpriteRenderer> ().enabled = false;
		transform.GetChild(0).GetComponent<SpriteRenderer> ().enabled = false;

	}

	//detectando lo que choca con este trigger
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "kahris"){
			tocandoWarp = true;

		}
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.tag == "kahris"){
			tocandoWarp = false;

		}
	}

	void Update(){


		//si entramos por una puerta?
		if(tocandoWarp && Input.GetKeyDown("x")){
			//animador
			lv_change.QuickFade();	
			StartCoroutine ("espera");
			//imprimir nombre de mapa (favor definir en targetmap)
			hudControl.ShowMapName(targetMap.name);

		}
	
	}

	IEnumerator espera (){
		yield return new WaitForSeconds (0.3f);
		kahris.transform.position = target.transform.GetChild (0).transform.position;

	}
}
