using UnityEngine;
using System.Collections;

public class Triturador : MonoBehaviour 
{
	
	void OnTriggerEnter(Collider colisionador)
	{
		Destroy(colisionador.gameObject);
	}
}
