using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour 
{
	public AnimationClip Collectar;
	
	void OnTriggerEnter(Collider colisionador)
	{
		if(colisionador.CompareTag("Player"))
		{
			collider.enabled = false;
			animation.Play(Collectar.name);
		}
	}
	
	public void Destruir()
	{
		Destroy(gameObject);
	}
	
}
