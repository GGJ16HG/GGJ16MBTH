using UnityEngine;
using System.Collections;

public class DestroyItem : MonoBehaviour 
{
	private GameObject levelManager;

	void Start ()
	{
		levelManager = GameObject.FindGameObjectWithTag("LevelManager");
	}

	void OnTriggerEnter(Collider objetoColision)
	{
		//Destrucción del objeto
		if(objetoColision.gameObject.CompareTag("Player")) 
		{
			Debug.Log("Jugador");
			Destroy(gameObject);
		}

	}
}
