using UnityEngine;
using System.Collections;

public class ControlCamara : MonoBehaviour 
{
	public float velocidad;
	public float porcentajeTolerancia = 0.1f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.mousePosition.x < Screen.width * porcentajeTolerancia)// * 0.1
		{
			//Mover Izquierda
			transform.Translate(Vector3.left * velocidad * Time.deltaTime, Space.World);
		}
		if(Input.mousePosition.x > Screen.width * (1-porcentajeTolerancia)) // 0.9
		{
			//Mover Izquierda
			transform.Translate(Vector3.right * velocidad * Time.deltaTime, Space.World);
		}
		
		if(Input.mousePosition.y < Screen.height * porcentajeTolerancia)// * 0.1
		{
			//Mover Izquierda
			transform.Translate(Vector3.back * velocidad * Time.deltaTime, Space.World);
		}
		if(Input.mousePosition.y > Screen.height * (1-porcentajeTolerancia)) // 0.9
		{
			//Mover Izquierda
			transform.Translate(Vector3.forward * velocidad * Time.deltaTime, Space.World);
		}	
	
	}
}
