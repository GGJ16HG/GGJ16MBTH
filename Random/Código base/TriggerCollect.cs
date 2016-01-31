using UnityEngine;
using System.Collections;

public class TriggerCollect : MonoBehaviour 
{	
	public bool modoSimple;
	public bool mandaInfo;
	public GameObject levelManager;
	
	public AnimationClip animacionColectar;
	public AudioClip audioColectar;
	
	void Start()
	{
		if(mandaInfo)
		if(levelManager==null)
		{
			levelManager = GameObject.FindGameObjectWithTag("LevelManager");
		}
	}
	
	void OnTriggerEnter(Collider objetoColision)
	{
		if(modoSimple)
		{
			if(objetoColision.CompareTag("Player"))
			{
		    	Destroy(gameObject);
			}
		}
		else
		{
			animation.Play(animacionColectar.name);
			audio.PlayOneShot(audioColectar);
		}
		
		if(mandaInfo)
		{
			levelManager.BroadcastMessage("IntrementarPuntaje",SendMessageOptions.DontRequireReceiver);
		}
	}	
	
	public void DestruirObjeto()
	{
		Destroy(gameObject);
	}
}
