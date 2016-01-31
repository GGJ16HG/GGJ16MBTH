using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class JuegoGUI : MonoBehaviour {
	
	private float puntajeActual;
	private GameObject levelManager;
	GUIStyle estiloMorado;
	Color morado;

	// Use this for initialization
	void Start () {
		
		levelManager = GameObject.FindGameObjectWithTag("LevelManager");
		morado = new Color(1.0f, 0.0f, 0.9f);
		estiloMorado = new GUIStyle();
		estiloMorado.normal.textColor = morado;
		estiloMorado.fontSize = 20;
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.puntajeActual = levelManager.GetComponent<LevelManager>().regresaPuntaje();
	}
	
	void OnGUI()
	{
		
		GUI.Label(new Rect(20, 320, 300, 50), "Score: "+this.puntajeActual, estiloMorado);
		
		/*
		if(GUI.Button(new Rect(200,200,200,200), "Plantas"))
		{
			levelManager.GetComponent<LevelManager>().DestruirLaberinto();
		}*/
	}
}
