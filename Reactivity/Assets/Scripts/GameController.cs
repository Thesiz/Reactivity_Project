using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public static GameController estadoJuego;

	//TODO: agrear efecto parallax en funcion de movimiento de jugador y no en cada frame
	//parallax
	public float parallaxSpeed = 0.2f;
	public RawImage background;
	public RawImage texturas;

	//gamestate

	public enum GameState {Stop, Playing}
	public GameState gameState = GameState.Stop;

	void Awake(){
		if (estadoJuego == null) {
			estadoJuego = this;
			DontDestroyOnLoad (gameObject);
		} else if (estadoJuego != this) {
			Destroy (gameObject);
		}

	}

	void Start () {
		
	}

	void Update () {

		//Comienza el juego
		if (gameState == GameState.Stop && (Input.GetKeyDown ("x") || Input.GetMouseButtonDown (0))) {
			gameState = GameState.Playing;


		} //juego en marcha
		else if (gameState == GameState.Playing) {
			//TODO: cambiar a nivel_1
			CambiarEscena("level_1");

		} else {
			Parallax ();
		}
	
	}


	public void Parallax () {
		float finalSpeed = parallaxSpeed * Time.deltaTime;
		background.uvRect = new Rect (background.uvRect.x + finalSpeed, 0f, 1f, 1f);
		texturas.uvRect = new Rect (texturas.uvRect.x + finalSpeed * 4, 0f, 1f, 1f);
	}


	public void CambiarEscena(string sceneName){
		print ("Cambiando a " + sceneName);
		SceneManager.LoadScene (sceneName);

	}
		
}
