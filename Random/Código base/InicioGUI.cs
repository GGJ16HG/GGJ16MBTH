using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class InicioGUI : MonoBehaviour 
{
	
	public int[] nivelCarga;
	public GUIStyle estilo;
	public GUISkin skin;
	
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
		

		
		GUI.Label(new Rect(250,100,100,100), "Revienta las esferas!", estilo);
		
		if(GUI.Button(  new Rect(300,150,100,50) , "Inicio"))
		{
			Debug.Log("Cargar el nivel " + nivelCarga);
			Application.LoadLevel(nivelCarga[0]);
		}
		
		if(GUI.Button(  new Rect(300,220,100,50) , "Instrucciones"))
		{
			Debug.Log("Cargar el nivel " + nivelCarga);
			Application.LoadLevel(nivelCarga[1]);
		}	
		
	}
}
