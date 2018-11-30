using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatusConst : MonoBehaviour {


	public static GameStatusConst estadoJuego;

	void Awake(){
		if (estadoJuego == null) {
			estadoJuego = this;
			DontDestroyOnLoad (gameObject);
		} else if (estadoJuego != this) {
			Destroy (gameObject);
		}

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
