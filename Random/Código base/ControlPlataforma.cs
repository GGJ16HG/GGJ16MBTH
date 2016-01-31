using UnityEngine;
using System.Collections;

public class ControlPlataforma : MonoBehaviour 
{
	public ControlFabrica miFabrica;
	
	void Update () 
	{
		transform.Translate(Vector3.left * miFabrica.velocidad * Time.deltaTime,Space.World);	
	}
}
