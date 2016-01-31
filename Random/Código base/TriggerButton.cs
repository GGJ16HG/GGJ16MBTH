using UnityEngine;
using System.Collections;

public class TriggerButton : MonoBehaviour 
{
	public int nivel;
	
	void OnTriggerEnter(Collider objetoColision)
	{
		if(objetoColision.CompareTag("Player"))
		{
			Application.LoadLevel(nivel);
		}		
	}
	

}
