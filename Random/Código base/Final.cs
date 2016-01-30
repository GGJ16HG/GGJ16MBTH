using UnityEngine;
using System.Collections;

[ExecuteInEditMode]

public class Final : MonoBehaviour 
{
	
	public GUISkin skin;
	public GUIStyle estilo;
	
	public int escena;
	
	private int puntaje;
	private int tiempo;

	// Use this for initialization
	void Start () 
	{
		
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void ObtenerDatos(int puntaje)
	{
		this.puntaje=puntaje;
		Debug.Log("Pantalla");
	}
	
	void OnGUI()
	{
		GUI.Label(new Rect(10,10,10,10), "Resultados", estilo);
		
		GUI.Label(new Rect(20,40,10,10), "Tiempo: ", estilo);
		
		GUI.Label(new Rect(20,80,10,10), "Puntos: ", estilo);
		
		if(GUI.Button(new Rect(200,200,100,50), "Volver al inicio"))
		{
			Application.LoadLevel(escena);
		}
	}
}
