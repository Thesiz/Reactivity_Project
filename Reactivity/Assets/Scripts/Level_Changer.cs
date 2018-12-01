using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Changer : MonoBehaviour {

	public Animator animator;

	// Update is called once per frame

	public void CambiarEscena (){
		StartCoroutine ("Cambiando");
	}

	IEnumerator Cambiando (){
		FadeToLavel (1);
		yield return new WaitForSeconds (3);
		Debug.Log ("Escena_cambiada! ");
		SceneManager.LoadScene ("level_1");

	}

	public void FadeToLavel(int levelIndex){
		animator.SetTrigger("FadeOut");

	}
}
