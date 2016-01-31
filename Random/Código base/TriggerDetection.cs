using UnityEngine;
using System.Collections;

public class TriggerDetection : MonoBehaviour 
{
	void OnTriggerEnter(Collider ObjetoColision)
	{
		if(ObjetoColision.gameObject.CompareTag("Player"))
		{
		 transform.parent.gameObject.BroadcastMessage("PlayerEnter",SendMessageOptions.DontRequireReceiver);
		}		
	}
	
	void OnTriggerExit(Collider ObjetoColision)
	{
		if(ObjetoColision.gameObject.CompareTag("Player"))
		{
		 transform.parent.gameObject.BroadcastMessage("PlayerExit",SendMessageOptions.DontRequireReceiver);
		}		
	}
	
}
