using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWormController : MonoBehaviour {

	//objeto atacado
	public string destroyState;
	public float timeForDisable;

	Animator anim;
	//objeto atacante
	CircleCollider2D attackCollider;
	public float attackTime;
	public int enemyPower = 15;



	// Use this for initialization
	void Start () {
		
		anim = GetComponent<Animator>();
		attackCollider = transform.GetChild (0).GetComponent<CircleCollider2D> ();
		//desactivando el attack colider al iniciar
		attackCollider.enabled = false;
	}

	IEnumerator OnTriggerEnter2D(Collider2D col){

		if(col.tag == "attack"){
			anim.Play (destroyState);
			yield return new WaitForSeconds (timeForDisable);
			foreach (Collider2D c in GetComponents <Collider2D>()) {
				c.enabled = false;
			
			}
		}
	
	
	}
	// Update is called once per frame
	void Update () {
		AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo (0);
		if(stateInfo.IsName(destroyState) && stateInfo.normalizedTime >= 1 ){
			Destroy (gameObject);
		}
	}

	void FixedUpdate(){
			StartCoroutine ("EnemyAttack");
	
	}

	IEnumerator EnemyAttack(){
		yield return new WaitForSeconds (attackTime);
		anim.SetTrigger ("wormattack");
		yield return new WaitForSeconds (0.2f);
		attackCollider.enabled = true;
		yield return new WaitForSeconds (0.3f);
		attackCollider.enabled = false;
	}
		
}

