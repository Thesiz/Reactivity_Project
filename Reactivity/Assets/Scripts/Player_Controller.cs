using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

	public float maxSpeed = 5f;
	public float speed = 2f;
	public bool grounded;

	//salto
	public float jumpPower = 6.5f;
	private Rigidbody2D rbKahris;
	private Animator anim;

	//salto
	private bool jumping;

	//TODO: ACTIVAR DOBLE SALTO CUANDO SUBAMOS DE NIVEL O NOS LO ENCEÑEN
	private bool doubleJump;
	//FIN 

	public bool frenar = false;

	// Use this for initialization
	void Start () {
		rbKahris = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		//instanciando la velocidad a mi anim
		anim.SetFloat ("kahris_speed", Mathf.Abs(rbKahris.velocity.x));
		//instanciando la velocidad a mi anim
		anim.SetBool("Kahris_on_ground",  grounded);

		//salto de precaucion
		if (grounded) {
			doubleJump = true;
		}

		if((Input.GetKeyDown(KeyCode.UpArrow ) || Input.GetKeyDown ("x") )){
			//tocando suelo?
			if(grounded){
				jumping = true;
				doubleJump = true;
			} else if (doubleJump){
				//AL TERMINAR EL JUEGO JUMPING DEBE SER = FALSE
				//AL GANAR HABILIDAD JUMPING DEBE SER = TRUE
				jumping = true;
				doubleJump = false;
			}
		}
	}

	void FixedUpdate(){

		//friccion artificial
		Vector3 frenandoVelocidad = rbKahris.velocity;
		frenandoVelocidad.x *= 0.75f;


		if (grounded) {
			rbKahris.velocity = frenandoVelocidad;
		}
			
		//velocidad y movimiento
		float h = Input.GetAxis ("Horizontal");
		rbKahris.AddForce (Vector2.right * speed * h);
		//Debug.Log (rbKahris.velocity.x);


		//limitando la velocidad
		float limitedSpeed = Mathf.Clamp (rbKahris.velocity.x, -maxSpeed, maxSpeed);
		rbKahris.velocity = new Vector2 (limitedSpeed,rbKahris.velocity.y);


		//cambiar direccion de sprite
		if (h > 0.1f) {
			transform.localScale = new Vector3 (1f,1f,1f);
		}
		if (h < -0.1f) {
			transform.localScale = new Vector3 (-1f,1f,1f);
		}

		//saltando?
		if (jumping){
			rbKahris.velocity = new Vector2 (rbKahris.velocity.x, 0);
			rbKahris.AddForce (Vector2.up * jumpPower, ForceMode2D.Impulse);
			jumping = false;
		}
	}
	//reaparicion
	void OnBecameInvisible(){
		transform.position = new Vector3 (-7.01f,-3.72f,-10f);
	
	}
}
