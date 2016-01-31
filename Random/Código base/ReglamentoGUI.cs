using UnityEngine;
using System.Collections;

[ExecuteInEditMode]

public class ReglamentoGUI : MonoBehaviour {

	//Variables para la creación de la interfaz
	
	public int escena;
	public GUIStyle estiloEscena;
	public GUISkin skinEscena;

	// Creación de la interfaz 
	
	void OnGUI()
	{
		//Variables para Rect: x, y, largo, alto
		
		if(GUI.Button(new Rect(240, 260, 190, 20), "Regresar a la pantalla de inicio"))
		{
			Application.LoadLevel("Start");
		}
		
	}
}
