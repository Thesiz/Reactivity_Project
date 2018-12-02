using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float maxSpeed = 1f;
	public float speed = 1f;

	private Rigidbody2D rbEnemy;

	// Use this for initialization
	void Start () {
		rbEnemy = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		//movimiento y velocidad
		rbEnemy.AddForce (Vector2.right * speed);
		float limitedSpeed = Mathf.Clamp (rbEnemy.velocity.x, -maxSpeed, maxSpeed);
		rbEnemy.velocity = new Vector2 (limitedSpeed,rbEnemy.velocity.y);

		//gestionando si choca cambiar direccion de velocidad
		if(rbEnemy.velocity.x > -0.01f && rbEnemy.velocity.x < 0.01f ){
			speed = -speed;
			rbEnemy.velocity = new Vector2 (speed,rbEnemy.velocity.y);
		}

		if (speed  < 0) {
			transform.localScale = new Vector3 (1f,1f,1f);
		} else if (speed > 0) {
			transform.localScale = new Vector3 (-1f,1f,1f);
		}

	}
}
