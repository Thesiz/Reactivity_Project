using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class KahrisHudController : MonoBehaviour {

	public Player_Controller player;

	public Animator anim;

	public float barraSalud;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		barraSalud = 100;
	}

	// Update is called once per frame
	void Update () {
		AlgoritmoBarra (player.controlSalud);
		print (player.controlSalud);

	}

	public void AlgoritmoBarra(float x){

		if(x >= 95 ){
			anim.SetTrigger ("100");
		}else if (x >= 90 && x < 95 ) {
			anim.SetTrigger ("90");

		}else if(x >= 80 && x < 90 ){
			anim.SetTrigger ("80");

		}else if(x >= 70 && x < 80 ){
			anim.SetTrigger ("70");

		}else if(x >= 60 && x < 70 ){
			anim.SetTrigger ("60");

		}else if(x >= 50 && x < 60 ){
			anim.SetTrigger ("50");

		}else if(x >= 40 && x < 50 ){
			anim.SetTrigger ("40");

		}else if(x >= 30 && x < 40 ){
			anim.SetTrigger ("30");

		}else if(x >= 15 && x < 30 ){
			anim.SetTrigger ("20");

		}else if(x >= 1 && x < 15 ){
			anim.SetTrigger ("10");

		}else if(x <= 0){
			anim.SetTrigger ("0_die");

		}

	}

}
