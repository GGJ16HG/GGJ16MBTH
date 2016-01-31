using UnityEngine;
using System.Collections;

public class CargarEscenas : MonoBehaviour {
	
	private int nivelActual;
	private bool nivelPoblado = false;
	
	
	// Use this for initialization
	void Start () {
		 
		DontDestroyOnLoad( GameObject.FindGameObjectWithTag("Player") ); //No destruir al Jugador
		DontDestroyOnLoad( gameObject );	//No destruir la Camara
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		if(GUI.Button(new Rect(10,10,100,20),"PoblarNivel"))
		{
			if(nivelPoblado == false)
			{
				Application.LoadLevelAdditive(1);
				Application.LoadLevelAdditive(2);
				Application.LoadLevelAdditive(3);
				nivelPoblado = true;
			}
		}
		if(GUI.Button(new Rect(10,30,100,20),"SiguienteNivel"))
		{
			if(nivelActual+1 > 3)
			{
				nivelActual = 0;
			}
			else
			{
				nivelActual++;
			}
			
			switch (nivelActual)
			{
				case 0:	Application.LoadLevel(0); Destroy(GameObject.FindGameObjectWithTag("Player")); Destroy(gameObject); break;
				case 1:	Application.LoadLevel(4); break;
				case 2:	Application.LoadLevel(5); break;
				case 3:	Application.LoadLevel(6); break;
			}
			nivelPoblado=false;
		}
		if(GUI.Button(new Rect(10,50,100,20),"NivelAnterior"))
		{
			if(nivelActual -1 <0)
			{
				nivelActual = 3;
			}
			else
			{
				nivelActual --;
			}
			switch (nivelActual)
			{
				case 0:	Application.LoadLevel(0); Destroy(GameObject.FindGameObjectWithTag("Player")); Destroy(gameObject); break;
				case 1:	Application.LoadLevel(4); break;
				case 2:	Application.LoadLevel(5); break;
				case 3:	Application.LoadLevel(6); break;
			}
			nivelPoblado=false;
		}		
	}//end OnGUI
}//end Class
