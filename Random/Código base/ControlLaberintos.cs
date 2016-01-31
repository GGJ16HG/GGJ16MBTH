using UnityEngine;
using System.Collections;

public class ControlLaberintos : MonoBehaviour {
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//DestruyeLaberinto();
	}
	
	void DestruyeLaberinto()
	{
		if(this.gameObject.CompareTag("Laberinto1"))
		{
			Debug.Log("Laberinto 1");
			Destroy(gameObject);
		}
		else if(this.gameObject.CompareTag("Laberinto2"))
		{
			Debug.Log("Laberinto 2");
			Destroy(gameObject);
		}
	}
}
