using UnityEngine;
using System.Collections;

/*
 * Script creado para mover el jugador
 */

public class MovimientoJugador : MonoBehaviour {
	
	//Velocidades 
	public float velocidadAvance;
	public float velocidadRotacion;
	
	
	// Use this for initialization
	void Start()
	{
	
	
		
	}
	
	// Update is called once per frame
	void Update() {
		
		Rotacion();
		Avance();
	
	}
	
	void Avance(){
		
		if(Input.GetAxis("Vertical") > 0)
		{
			Debug.Log("Avanzo");
			this.transform.Translate(Vector3.forward * velocidadAvance*Time.deltaTime); 
		
		}
		else if(Input.GetAxis("Vertical") < 0)
		{
			Debug.Log("Retrocedo");
			this.transform.Translate(Vector3.forward * -velocidadAvance*Time.deltaTime); 
		}
		
	}
	
	void Rotacion(){
		
		if(Input.GetAxis("Horizontal") > 0)
		{
			Debug.Log("Roto a la derecha");
			this.transform.Rotate(0, velocidadRotacion*Time.deltaTime,0,Space.World);
		}
		else if(Input.GetAxis("Horizontal") < 0)
		{
			this.transform.Rotate(0, -velocidadRotacion*Time.deltaTime,0,Space.World);
			Debug.Log("Roto a la izquierda");
		}
		
	}
}
