using UnityEngine;
using System.Collections;

public class ControlSimple : MonoBehaviour {
	
	public float velocidad;
		
	void Start () {
	
	}
		
	void Update () 	
	{
		transform.Translate(
		new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * velocidad * Time.deltaTime 
							);
	
	}
}
