using UnityEngine;
using System.Collections;

public class ControladorPersonaje : MonoBehaviour {

	public float fuerzasalto = 0.3f;
	//private bool enSuelo = true;
	//private bool dobleSalto = false;
	//public Transform comprobadorSuelo;
	//float comprobadorRadio = 0.07f;
	//public LayerMask mascaraSuelo;
	private bool caminando = false;
	private bool saltando = false;
	private bool corriendo = false;
	public float velociad = 3f;

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

		caminando = false;
		saltando = false;
		corriendo = false;

	}

	void Update () {

		if(Input.GetKey(KeyCode.RightArrow))
		{
			this.transform.Translate (velociad * Time.deltaTime,0f,0f,Space.World);
			caminando = true;
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			this.transform.Translate (-velociad * Time.deltaTime,0f,0f,Space.World);
			//rotar
			caminando = true;
		}
		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			this.transform.Translate(0f,fuerzasalto,0f,Space.World);
			saltando = true;
		}
		if(Input.GetKey(KeyCode.Space))
		{
			this.transform.Translate((velociad*2)*Time.deltaTime,0f,0f,Space.World);
			corriendo = true;
		}


	}
}
