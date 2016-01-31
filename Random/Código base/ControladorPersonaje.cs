using UnityEngine;
using System.Collections;

public class ControladorPersonaje : MonoBehaviour {

	public float velocidadCaminar;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			this.transform.Translate(- velocidadCaminar * Time.deltaTime, 0f, 0f, Space.World);
			Debug.Log("Derecha");
		}

		if(Input.GetKey(KeyCode.RightArrow))
		{
			this.transform.Translate(velocidadCaminar * Time.deltaTime, 0f, 0f, Space.World);
			Debug.Log("Izquierda");
		}
	}
}
