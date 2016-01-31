using UnityEngine;
using System.Collections;

public class RotateForever : MonoBehaviour 
{
	public Vector3 ejeRotacion;
	public float velocidad;
	
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		gameObject.transform.Rotate(ejeRotacion * velocidad * Time.deltaTime);	
	}
}
