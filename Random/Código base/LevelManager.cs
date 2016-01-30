using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
	public bool puntaje;
	public bool limiteTiempo;
	public bool resistirTiempo;
	
	public int puntajeObjetivo;
	public float tiempoMaximo;
	public float tiempoMinimo;
	
	private int puntajeObtenido;
	private bool gano = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if(limiteTiempo)
		{
		 if(Time.time > tiempoMaximo)
		 {			
			if(puntaje)
			{
				if(puntajeObtenido < puntajeObjetivo)
				{
					gano = false;
				}				
			}
				Debug.Log("1");
			terminarJuego();
		 }
		}
		else if(puntaje)
		{
		  if(puntajeObtenido>= puntajeObjetivo)
			{
				Debug.Log("2");
				terminarJuego();
			}
		}
		
		if(resistirTiempo)
		{
		if(Time.time > tiempoMinimo)
		{			
			Debug.Log("3");
			terminarJuego();			
		}
		}	
		
	}
	
	
	private void terminarJuego()
	{
		if(gano == true)
		{
			Application.LoadLevel(2);
		}
		else if (gano == false)
		{
			Application.LoadLevel(3);
		}
		
	}
	
	public void IntrementarPuntaje()
	{
		puntajeObtenido ++;
	}
	
	void OnGUI()
	{
		if(puntaje)
		GUI.Box(new Rect(50,50, 70,25), "("+puntajeObtenido+" / "+puntajeObjetivo+")"); //  (15/20)
		
		if(limiteTiempo)
		GUI.Box(new Rect(50,80, 150,25), "Restante: "+ (tiempoMaximo - Time.time) + " seg."); //  Restante: 55.06 Seg
		
		if(resistirTiempo)
		GUI.Box(new Rect(50,110, 150,25), "["+ Time.time + " seg / "+tiempoMinimo+" seg]"); //  [10.05 seg / 100 seg]
	}
	
}
