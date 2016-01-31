using UnityEngine;
using System.Collections;

public class PersonajeNormal : MonoBehaviour {
	public float velocidad;
	public float gravedad;
	public float velocidadBrinco;
	
	
	private Vector3 direccionMovimiento;
	private CharacterController controlador;
	
	// Use this for initialization
	void Start () 
	{
		controlador = gameObject.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () 
	{		
		if(controlador.isGrounded) //Moverse
		{			
			direccionMovimiento = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
			direccionMovimiento = transform.TransformDirection(direccionMovimiento);
			direccionMovimiento = direccionMovimiento * velocidad;
			if(Input.GetKeyDown(KeyCode.Space))
			{
				direccionMovimiento.y = velocidadBrinco;
			}
		}
		
		direccionMovimiento.y -= gravedad * Time.deltaTime;
		
		controlador.Move(direccionMovimiento * Time.deltaTime);
		
		
	
	}
}
