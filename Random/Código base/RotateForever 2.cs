using UnityEngine;
using System.Collections;

public class RotateForever : MonoBehaviour {

	public float velocidad;
	public Vector3 eje;
	
	void Update () 
	{		
		transform.Rotate(eje * velocidad * Time.deltaTime);	
	}
}
