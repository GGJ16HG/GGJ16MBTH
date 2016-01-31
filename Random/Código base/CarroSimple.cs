using UnityEngine;
using System.Collections;

public class CarroSimple : MonoBehaviour 
{
	public WheelCollider llanta_FD, llanta_FI, llanta_TD, llanta_TI;
	public GameObject llanta_V_FD, llanta_V_FI, llanta_V_TD, llanta_V_TI;
	
	
	public float velocidad;
	public float anguloMaximo = 45.0f;
	public bool traccionF, taccionT, traccion4x4;
	
	
	// Use this for initialization
	void Start () 
	{
		gameObject.rigidbody.centerOfMass = new Vector3(0,-0.9f,0);
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		//Rotar Directamente las llantas
		//Giro de Avance		
		llanta_V_FD.transform.Rotate(Vector3.right * ((llanta_FD.rpm/60) * 360) * Time.deltaTime);		
		llanta_V_FI.transform.Rotate(Vector3.right * ((llanta_FD.rpm/60) * 360) * Time.deltaTime);
		llanta_V_TD.transform.Rotate(Vector3.right * ((llanta_FD.rpm/60) * 360) * Time.deltaTime);
		llanta_V_TI.transform.Rotate(Vector3.right * ((llanta_FD.rpm/60) * 360) * Time.deltaTime);
		
		
		//Girar llantas forzando el giro directamente
		llanta_V_FD.transform.localEulerAngles = new Vector3(llanta_V_FD.transform.localEulerAngles.x,
														   llanta_FD.steerAngle - llanta_V_FD.transform.localEulerAngles.z,
														   llanta_V_FD.transform.localEulerAngles.z);
		
		llanta_V_FI.transform.localEulerAngles = new Vector3(llanta_V_FI.transform.localEulerAngles.x,
														   llanta_FI.steerAngle - llanta_V_FI.transform.localEulerAngles.z,
														   llanta_V_FI.transform.localEulerAngles.z);
		
		
		/*
		//Calcular Quaternions de giro y entonces Asignar a la rotacion de las llantas
		llanta_V_FD.transform.rotation = Quaternion.Euler( llanta_FD.rpm/60*360 , llanta_FD.steerAngle, 0); 
		llanta_V_FI.transform.rotation = Quaternion.Euler( llanta_FI.rpm/60*360 , llanta_FI.steerAngle, 0);
		*/
		
		
	}
	
	void FixedUpdate()
	{
		llanta_FD.motorTorque = Input.GetAxis("Vertical")*velocidad;
		llanta_FI.motorTorque = Input.GetAxis("Vertical")*velocidad;		
		
		llanta_FD.steerAngle = anguloMaximo * Input.GetAxis("Horizontal");
		llanta_FI.steerAngle = anguloMaximo * Input.GetAxis("Horizontal");
	}
	
}
