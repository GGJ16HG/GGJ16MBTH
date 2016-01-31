using UnityEngine;
using System.Collections;

public enum tiposCheck
{
	Inicio, Final
}

public class ControlCheckPoint : MonoBehaviour 
{

	public tiposCheck TiposDeCheck;

	void OnTriggerEnter(Collider objetoColision)
	{
		if(objetoColision.gameObject.CompareTag("Player"))
		{
			Debug.Log("Great!! chocamos");
			//Destroy(gameObject);
		}
	}
}