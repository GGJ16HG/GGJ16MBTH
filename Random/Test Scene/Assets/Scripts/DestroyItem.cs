using UnityEngine;
using System.Collections;

public class DestroyItem : MonoBehaviour 
{
	private GameObject levelManager;

	void Start ()
	{
		levelManager = GameObject.FindGameObjectWithTag("LevelManager");
		Debug.Log("Destroy");
	}

	void OnTriggerEnter(Collider objetoColision)
	{
		
	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log("Objeto");
	}
}
