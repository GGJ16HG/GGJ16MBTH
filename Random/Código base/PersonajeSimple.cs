using UnityEngine;
using System.Collections;

public class PersonajeSimple : MonoBehaviour 
{
	public float velocidad;
	public float velocidadGiro;
	
	private Vector3 direccionMovimiento;
	private CharacterController controlador;
	
	/* Variables para el Damp
	public float tiempoAceleracion;
	private float refVelocidad;
	private float velocidadHorizontal;
	private int direccionHorizontal;
	*/
	
	void Start () 
	{
		controlador = gameObject.GetComponent<CharacterController>();
	}
	
	
	void Update () 
	{
		/*
		//Movimiento Tipo Tanque, Resident Evil
		//direccionMovimiento = new Vector3(0, 0, Input.GetAxis("Vertical"));		
		direccionMovimiento = gameObject.transform.forward * Input.GetAxis("Vertical");		
		//gameObject.transform.Rotate(0, velocidadGiro * Time.deltaTime *Input.GetAxis("Horizontal"), 0);
		gameObject.transform.Rotate(Vector3.up * velocidadGiro * Time.deltaTime * Input.GetAxis("Horizontal"));		
		controlador.SimpleMove(direccionMovimiento * velocidad);
		*/
		/* //relativo a Mundo
		direccionMovimiento = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));		
		if(Input.GetAxis("Horizontal") !=0 || Input.GetAxis("Vertical") !=0)
		gameObject.transform.rotation = Quaternion.LookRotation(direccionMovimiento);		
		controlador.SimpleMove(direccionMovimiento * velocidad);
		*/		
		
		//Relativo a Camara Casi tipo Devil May Cry		
		direccionMovimiento = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));		
		
		Vector3 relativoCamara = Camera.mainCamera.transform.TransformDirection(direccionMovimiento );		
				
		if(Input.GetAxis("Horizontal") !=0 || Input.GetAxis("Vertical") !=0)
		gameObject.transform.rotation = Quaternion.LookRotation(relativoCamara);		
		controlador.SimpleMove(relativoCamara * velocidad);		 
		 
	}
	
}


/*
 if(Input.GetAxis("Horizontal")!=0)
		{
			velocidadHorizontal = Mathf.SmoothDamp(velocidadHorizontal,velocidad,ref refVelocidad, tiempoAceleracion);
			if(Input.GetAxis("Horizontal")>0)
			{ 
				direccionHorizontal = 1; 
			}
			else
			{ 
				direccionHorizontal = -1;
			}			
		}
		else//cuando es 0
		{
			velocidadHorizontal = Mathf.SmoothDamp(velocidadHorizontal,0, ref refVelocidad, tiempoAceleracion);
		}
		
		gameObject.transform.Translate(Vector3.right * direccionHorizontal *velocidadHorizontal * Time.deltaTime,Space.World);
 
 */