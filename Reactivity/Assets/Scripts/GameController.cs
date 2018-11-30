using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	//TODO: agrear efecto parallax en funcion de movimiento de jugador y no en cada frame
	public float parallaxSpeed = 0.2f;
	public RawImage background;
	public RawImage texturas;

	public enum GameState {stop, playing}
	public GameState gameState = GameState.stop;	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//Comienza el juego
		if(gameState == GameState.stop && (Input.GetKeyDown("up") || Input.GetKeyDown("x") || Input.GetMouseButtonDown(0))){
			gameState = GameState.playing;
		}


		float finalSpeed = parallaxSpeed * Time.deltaTime;
		background.uvRect = new Rect (background.uvRect.x + finalSpeed, 0f, 1f, 1f);
		texturas.uvRect = new Rect (texturas.uvRect.x + finalSpeed * 4, 0f, 1f, 1f);
		
	}
}
