using UnityEngine;
using System.Collections;

public class Destructor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.CompareTag("Player")) {
			Debug.Break();
			//Fin del juego
			Debug.Log("Player muere");
		}

		if(other.gameObject.CompareTag("item"))
		{
			Destroy (other.gameObject);
			Debug.Log("Destructor en accion");
		}
	}
}
