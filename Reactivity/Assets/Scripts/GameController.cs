using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public Level_Changer levelChanger;

	//TODO: agrear efecto parallax en funcion de movimiento de jugador y no en cada frame

	public float parallaxSpeed = 0.2f;
	public RawImage background;
	public RawImage piso;


	public enum GameState {Stop, Playing}
	public GameState gameState = GameState.Stop;

	//Parallax
	public void Parallax () {
		float finalSpeed = parallaxSpeed * Time.deltaTime;
		background.uvRect = new Rect (background.uvRect.x + finalSpeed, 0f, 1f, 1f);
		piso.uvRect = new Rect (piso.uvRect.x + finalSpeed * 4, 0f, 1f, 1f);
	}

	void Start () {
		Debug.Log ("helloWorld");
	}



	void Update () {

		//Inicializando el juego
		if (gameState == GameState.Stop && (Input.GetKeyDown ("x") || Input.GetMouseButtonDown (0))) {
			gameState = GameState.Playing;


		} //si oprimo x que hacer?
		else if (gameState == GameState.Playing) {
			levelChanger.CambiarEscena();

		} else {
			Parallax ();
		}
	
	}
}
