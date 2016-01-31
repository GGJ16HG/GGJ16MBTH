using UnityEngine;
using System.Collections;

public class ControlLinea : MonoBehaviour {
	public Transform inicio, final;
	private LineRenderer linea;
	
	// Use this for initialization
	void Start () {
		linea = gameObject.GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		linea.SetPosition(0, inicio.position);
		linea.SetPosition(1, final.position);	
	}
}
