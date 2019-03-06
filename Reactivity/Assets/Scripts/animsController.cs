using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animsController : MonoBehaviour {

	public bool accion;
	private Animator anim;

	void Start () {
		anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool("accion",  accion);
	}
	public void Animando(){
		accion = true;
	}
	public void NoAnimando(){
		accion = false;
	}
}
