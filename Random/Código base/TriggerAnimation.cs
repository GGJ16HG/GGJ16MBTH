using UnityEngine;
using System.Collections;

public class TriggerAnimation : MonoBehaviour 
{
	public AnimationClip animacionEntrada;
	public AnimationClip animacionSalida;

	// Use this for initialization
	void Start () 
	{
		animation.Play(animacionSalida.name);	
	}

	void OnTriggerEnter(Collider objetoColision)
	{
		if(objetoColision.CompareTag("Player"))
		{
			animation.Play(animacionEntrada.name);
		}		
	}
	
	void OnTriggerExit(Collider objetoColision)
	{
		if(objetoColision.CompareTag("Player"))
		{
			animation.Play(animacionSalida.name);
		}		
	}
	
}
