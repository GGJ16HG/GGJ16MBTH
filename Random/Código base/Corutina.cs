using UnityEngine;
using System.Collections;

public class Corutina : MonoBehaviour 
{
	public Material rojo, azul, amarillo;
		
	void Start () 
	{
		gameObject.renderer.material = azul;	
	}
		
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log("Presiona Espacio: " + Time.time);
			gameObject.renderer.material = rojo;
			//Quiero que pase X cantidad de tiempo y regrese a Azul
			StartCoroutine(CoorutinaRegresarColor());
			Invoke("CambiaAmarillo",3.0f);
		}	
	}
	
	IEnumerator CoorutinaRegresarColor()
	{
		Debug.Log("Entra: " + Time.time);
		yield return new WaitForSeconds(1.0f);
		gameObject.renderer.material = azul;
		Debug.Log("Sale: " + Time.time);
		
	}
	
	void CambiaAmarillo()
	{
		Debug.Log("Cambia a Amarillo: " + Time.time);
		gameObject.renderer.material = amarillo;
		StartCoroutine(CoorutinaRegresarColor());
	}
	
}
