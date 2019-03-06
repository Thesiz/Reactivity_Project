using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class Player_Controller : MonoBehaviour {

	public int controlSalud = 100;
	public EnemyWormController ataqueGusano;

	public float maxSpeed = 5f;
	public float speed = 2f;
	public bool grounded;
	public ParticleSystem dust;

	//fisica de salto
	public float jumpPower = 6.5f;
	private Rigidbody2D rbKahris;
	private Animator anim;

	public bool atacar;
	public bool meAtacan;
	//salto booleano
	private bool jumping;

	//TODO: ACTIVAR DOBLE SALTO CUANDO SUBAMOS DE NIVEL O NOS LO ENCEÑEN
	private bool doubleJump;
	//FIN 

	public bool frenar = false;

	CircleCollider2D attackCollider;


	// Use this for initialization
	void Start () {
		atacar = true;
		rbKahris = GetComponent<Rigidbody2D>();


		anim = GetComponent<Animator>();
		attackCollider = transform.GetChild (2).GetComponent<CircleCollider2D> ();
		//desactivando el attack colider al iniciar
		attackCollider.enabled = false;
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

		if(Input.GetKeyDown(KeyCode.UpArrow)){
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

		//detectar ataque, tiene prioridad porque va abajo del todo
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

		if(h != 0f){
			rbKahris.AddForce (Vector2.right * speed * h);
		}

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

		//atacando?
		if(Input.GetKeyDown("c") && atacar){
			atacar = false;
			StartCoroutine ("Ataque");
		}

	
	}
		
	IEnumerator Ataque (){
		anim.SetTrigger ("atacando");
		attackCollider.enabled = true;
		yield return new WaitForSeconds (0.2f);
		attackCollider.enabled = false;
		atacar = true;
	}
	//reaparicion
	/*void OnBecameInvisible(){
		transform.position = new Vector3 (0f,0f,-10f);
	
	}*/

	//sistema de particulas
	void DustPlay(){
		dust.Play ();
	}
	void DustStop(){
		dust.Stop ();
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "enemy_attack" && (!meAtacan)) {
			StartCoroutine ("SiendoAtacado");

		}
	
	}
		
	IEnumerator SiendoAtacado(){
		controlSalud -= ataqueGusano.enemyPower;
		meAtacan = true;
		yield return new WaitForSeconds (3f);
		meAtacan = false;
	}
}
