using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level_Changer : MonoBehaviour {

	public Animator animator;



	// Update is called once per frame
	void Start(){
		
	}


	//cambio lento
	public void CambiarEscena (){
		StartCoroutine ("CambiandoEscena");
	}

	IEnumerator CambiandoEscena (){
		FadeToLavel (1);
		yield return new WaitForSeconds (3);
		Debug.Log ("Escena_cambiada! ");
		SceneManager.LoadScene ("Acto_1");

	}
		
	public void FadeToLavel(int levelIndex){
		animator.SetTrigger("FadeOut");

	}

	//cambio rapido
	IEnumerator CambiandoQuick (){
		animator.SetTrigger("quickout");
		yield return new WaitForSeconds (1);
		animator.SetTrigger("quickin");

	}
	public void QuickFade(){
		StartCoroutine ("CambiandoQuick");

	}


}
