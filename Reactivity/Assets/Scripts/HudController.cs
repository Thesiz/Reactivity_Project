using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour {



	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		
	}


	//progrmama mostrar nombre area
	public void ShowMapName(string name){

		transform.GetChild (1).GetComponent<Text> ().text = name;
		transform.GetChild (2).GetComponent<Text> ().text = name;


	}
}
