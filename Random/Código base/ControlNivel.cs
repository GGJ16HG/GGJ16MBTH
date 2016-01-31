using UnityEngine;
using System.Collections;

public class ControlNivel : MonoBehaviour 
{
	
	public GUISkin skin;
	public GUIStyle style;
	
	//Tiempo límite en minutos
	public int tiempoLimite;
	private int tiempoBaseSegundos;
	private int tiempoBaseMinutos;
	private int tiempoBase;
	private int baseTiempo;
	private int segundos;
	private string tiempo;
	
	//Level Manager
	private GameObject levelManager;
	
	
	//Puntaje inicial
	public float puntajeInicial;
	private float puntajeActual;
	
	//Esferas a posicionar
	public GameObject[] esferas;
	public GameObject[] posiciones;
	
	// Use this for initialization
	void Start () 
	{
		puntajeActual = puntajeInicial;
		tiempoBaseSegundos = 0;
		tiempoBaseMinutos = 0;
		tiempoBase = 0;
		baseTiempo = 1;
		segundos = 60;
		
		PosicionaEsferas();
	}
	
	// Update is called once per frame
	void Update () 
	{
		CalculoTiempo();
	}
	
	void OnGUI()
	{
		
		GUI.Label(new Rect(100, 100, 300, 50), "Score: "+puntajeActual);
		//GUI.Label(new Rect(100, 150, 300, 50), tiempo);
	
	}
	
	public void AumentaPuntaje(float puntos)
	{
		puntajeActual = puntajeActual + puntos;
	}
	
	public void DisminuyePuntaje(float puntos)
	{
		puntajeActual = puntajeActual - puntos;
	}
	
	void CalculoTiempo()
	{
		tiempoBase = (int)Time.time;
		tiempoBaseSegundos++;
		
		if(tiempoBase <10)
		{
			tiempo = "Tiempo restante: "+ "0"+tiempoBase;
		}
		else
		{
			tiempo = "Tiempo restante: "+tiempoBase;
		}
	}
	
	void PosicionaEsferas()
	{
		int posicionador = 0;
		
		for(int i = 0; i<183; i++)
		{
			
			Instantiate(esferas[posicionador],posiciones[i].transform.position, Quaternion.identity);
			
			posicionador++;
			
			if(posicionador == 7)
			{
				posicionador = 0;
			}
			
		}
	}
	
}
