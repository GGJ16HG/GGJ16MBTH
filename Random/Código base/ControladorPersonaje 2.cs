using UnityEngine;
using System.Collections;

public class ControladorPersonaje : MonoBehaviour {

	public float fuerzasalto = 1f;
	private bool caminando = false;
	private bool saltando = false;
	private bool corriendo = false;
	private bool volteaIzq = false;
	private bool volteaDer = true;
	//private bool enSuelo = false;
	public float velociad = 3f;
	//public Transform papa;


	private Animator animator;


	void Awake (){

		animator = GetComponent<Animator>();
	
	}

	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate(){

		animator.SetBool ("KeyWalk", caminando);
		animator.SetBool ("KeyJump", saltando);
		animator.SetBool("KeyRun",corriendo);
		//animator.SetBool ("InGround", enSuelo);

		caminando = false;
		saltando = false;
		corriendo = false;
		//enSuelo = false;

	}

	void Update () {

		/*if (transform.rotation.eulerAngles.z < 30) {
			Debug.Log(transform.rotation.eulerAngles.z);
						enSuelo = true;
				} else {
						enSuelo = false;
				}*/

		if(Input.GetKey(KeyCode.RightArrow) )
		{
			//NotificationCenter.DefaultCenter ().PostNotification (this, "EmpiezaCorrer");
			this.transform.Translate (velociad * Time.deltaTime,0f,0f,Space.World);
			if(volteaIzq)
			{
				this.transform.Rotate (0f,180f,0f,Space.Self);
				volteaIzq = false;
				volteaDer = true;
			}
			caminando = true;

		}
		if(Input.GetKey(KeyCode.LeftArrow) )
		{
			//NotificationCenter.DefaultCenter ().PostNotification (this, "EmpiezaCorrer");
			this.transform.Translate (-(velociad * Time.deltaTime),0f,0f,Space.World);
			if(volteaDer)
			{
				this.transform.Rotate (0f,180f,0f,Space.Self);
				volteaDer = false;
				volteaIzq = true;
			}
			caminando = true;
		}
		if (Input.GetKey (KeyCode.UpArrow) && !(Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.Space))) 
		{

			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,fuerzasalto);
			saltando = true;
		}

		if(Input.GetKey(KeyCode.Space))
		{
			//NotificationCenter.DefaultCenter ().PostNotification (this, "EmpiezaCorrer");
			if(volteaDer)
				this.transform.Translate((velociad*2)*Time.deltaTime,0f,0f,Space.World);
			if(volteaIzq)
				this.transform.Translate((-velociad*2)*Time.deltaTime,0f,0f,Space.World);

			corriendo = true;
		}


	}
}
