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
			//Se detecta el tipo de etiqueta, y se disminuye el contador de los objetos
			//existentes
			if(gameObject.tag.Equals("Pollo"))
			{
				Debug.Log("Esto es un pollo");
			}
			else if(gameObject.tag.Equals("Bota"))
			{
				Debug.Log("Esto es una bota");
			}
			else if(gameObject.tag.Equals("Vial"))
			{
				Debug.Log("Esto es un vial");
			}
			else if(gameObject.tag.Equals("Capa"))
			{
				Debug.Log("Esto es una capa");
			}
			Destroy(gameObject);
		}

	}
}
