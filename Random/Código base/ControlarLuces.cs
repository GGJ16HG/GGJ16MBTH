using UnityEngine;
using System.Collections;

public class ControlarLuces : MonoBehaviour {
	
	
	public GameObject jugador;
	public GameObject iluminacion;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider Jugador)
	{
		if(jugador.gameObject.CompareTag("Player"))
		{
			Debug.Log("Aqui debo encenderme");
		}
		
	}
	
	void OnTriggerExit()
	{
		if(jugador.gameObject.CompareTag("Player"))
		{
			Debug.Log("Aqui debo apagarme");
		}
	}
}
