using UnityEngine;
using System.Collections;

public class ColliderButton : MonoBehaviour 
{
	
	//Variables
	public int nivel;
		
	//Funciones		
	void OnMouseUp()
	{
		//Cargar Nivel
	    Application.LoadLevel(nivel);
	}
	
	
}
