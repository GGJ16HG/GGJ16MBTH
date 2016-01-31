using UnityEngine;
using System.Collections;

[ExecuteInEditMode]

public class MuestraInstrucciones : MonoBehaviour 
{
	
	public int escena;
	
	public GUISkin skin;
	
	public GUIStyle estilo;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnGUI()
	{
		GUI.Label(new Rect(50, 50, 300,50), "Instrucciones:", estilo);
		
		GUI.Label(new Rect(100, 100, 300,50), "Gana mas de 100 puntos en menos de dos minutos.",estilo);
		
		GUI.Label(new Rect(100, 200, 300,50), "Pero cuidado: no todas las esferas son confiables.", estilo);
		
		if(GUI.Button(new Rect(300,300,100,50), "Regresar"))
		{
			Application.LoadLevel(escena);
		}
	}
}
