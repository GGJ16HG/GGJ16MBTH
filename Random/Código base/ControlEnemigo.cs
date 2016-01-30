using UnityEngine;
using System.Collections;

public class ControlEnemigo : MonoBehaviour 
{
	
	void OnTriggerEnter(Collider objetoColision)
	{
		if(objetoColision.gameObject.CompareTag("Player"))
		{
			Debug.Log("Hola");
			Destroy(gameObject);
		}
	}
}
