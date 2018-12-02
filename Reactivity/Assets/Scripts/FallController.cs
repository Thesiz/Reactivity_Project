using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallController : MonoBehaviour {


	public float fallDelay = 1f;
	public float respawnDelay = 5f;


	private Rigidbody2D rb2d;
	private EdgeCollider2D ed2d;
	private Vector3 start;


	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		ed2d = GetComponent<EdgeCollider2D> ();
		start = transform.position;


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.CompareTag ("kahris")) {
			Invoke ("Fall", fallDelay);
			Invoke ("Respawn", fallDelay + respawnDelay);
		}

	}

	void Fall(){
		rb2d.isKinematic = false;
		//no gestiona fuerzas en otros elementos
		ed2d.isTrigger = true;
	}

	void Respawn(){
		transform.position = start;
		rb2d.isKinematic = true;
		rb2d.velocity = Vector3.zero;
		ed2d.isTrigger = false;
	}
}
