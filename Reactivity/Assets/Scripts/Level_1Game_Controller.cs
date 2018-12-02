using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_1Game_Controller : MonoBehaviour {

	public float parallaxSpeed = 0.02f;
	public RawImage background;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		
	}

	public void ParallaxGoFoward () {
		float finalSpeed = parallaxSpeed * Time.deltaTime;
		background.uvRect = new Rect (background.uvRect.x + finalSpeed, 0f, 1f, 1f);
	}

	public void ParallaxGoBack () {
		float finalSpeed = parallaxSpeed * Time.deltaTime;
		background.uvRect = new Rect (background.uvRect.x - finalSpeed, 0f, 1f, 1f);
	}
}
