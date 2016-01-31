using UnityEngine;
using System.Collections;

[ExecuteInEditMode]

public class ContinuarJuego : MonoBehaviour 
{
	//Variables para la creación de la interfaz
	
	public GUIStyle estiloEscena;
	public GUISkin skinEscena;

	// Creación de la interfaz 
	
	void OnGUI()
	{
		//Variables para Rect: x, y, largo, alto
		
		GUI.Label(new Rect(10, 10, 200, 200), "Run, brother. Help me!");
		
		GUI.Label(new Rect(10, 30, 200, 200), "Desea continuar el juego?");
		
		if(GUI.Button(new Rect(10, 60, 100, 20), "Yes"))
		{
			Application.LoadLevel("Start");
		}
		
		if(GUI.Button(new Rect(10, 100, 100, 20), "No"))
		{
			
		}
	}
}
