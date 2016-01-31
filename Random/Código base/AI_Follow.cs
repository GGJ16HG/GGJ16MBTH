using UnityEngine;
using System.Collections;

public class AI_Follow : MonoBehaviour 
{
	public GameObject target; //gameObject.GetComponent<NavMeshAgent>().destination = target.transform.position;
	public Material matEstatico, matCazeria, matImpacto;
	
	private EstadosPosibles estadoActual;
	private EstadosPosibles estadoAnterior;	
	private bool entrada;//Esto es para la maquina de estados
	
	private bool jugadorEnRango;
	//private bool jugadorVisible;
	
	public enum EstadosPosibles
	{
		Inicio, //A
		Estatico, //B
		Cazeria, //C
		Impacto, //E
		Muerte, //D
	}
	
	// Use this for initialization
	void Start () 
	{
		estadoActual = EstadosPosibles.Inicio;
		entrada=true;	
	}
	
	// Update is called once per frame
	void Update () 
	{		
		MaquinaEstados();
	}
	
	void MaquinaEstados()
	{
		//Codigo de maquina
		//Definir en que estado estoy
		switch(estadoActual)
		{
			//------------------------------------------------------------------------------ Estado Inicio
		 case EstadosPosibles.Inicio:
		 {			
		  //Codigo Entrada
			if(entrada)
			{
				target = GameObject.FindGameObjectWithTag("Player");
				jugadorEnRango=false;
				entrada=false;
			}
		  //Codigo Constante
		     //Evaluando mi condicion de salida
		     //Cambiar de Estado
			 estadoActual = EstadosPosibles.Estatico;
		  //Codigo Salida
			if(estadoActual != EstadosPosibles.Inicio)
			{
				entrada=true;
			}			
		  }break;
			//======================================================================================			
			
			//------------------------------------------------------------------------------ Estado Estatico
		 case EstadosPosibles.Estatico:
		 {			
		  //Codigo Entrada
			if(entrada)
			{
				gameObject.GetComponent<Renderer>().material = matEstatico;				
				entrada=false;				
			}
		  //Codigo Constante
		     //Evaluando mi condicion de salida
			if(jugadorEnRango)// Cambio a Estado B
			{
				estadoActual=EstadosPosibles.Cazeria;
			}		
			
		     //Cambiar de Estado
		  //Codigo Salida
			if(estadoActual != EstadosPosibles.Estatico)
			{
				entrada=true;
			}			
		  }break;
			//======================================================================================	
			
			//------------------------------------------------------------------------------ Estado Cazeria
		 case EstadosPosibles.Cazeria:
		 {			
		  //Codigo Entrada
			if(entrada)
			{
				gameObject.GetComponent<Renderer>().material = matCazeria;//Coloreo para cazar
				entrada=false;
			}
		  //Codigo Constante
			gameObject.GetComponent<NavMeshAgent>().destination = target.transform.position;
		     //Evaluando mi condicion de salida
			if(!jugadorEnRango)
			{
				estadoActual= EstadosPosibles.Estatico;
			}
		     //Cambiar de Estado
		  //Codigo Salida
			if(estadoActual != EstadosPosibles.Cazeria)
			{
				gameObject.GetComponent<NavMeshAgent>().Stop();
				entrada=true;
			}			
		  }break;
			//======================================================================================	
			//------------------------------------------------------------------------------ Estado Impacto
		 case EstadosPosibles.Impacto:
		 {			
		  //Codigo Entrada
			if(entrada)
			{
				entrada=false;
			}
		  //Codigo Constante
		     //Evaluando mi condicion de salida
		     //Cambiar de Estado
		  //Codigo Salida
			if(estadoActual != EstadosPosibles.Impacto)
			{
				entrada=true;
			}			
		  }break;
			//======================================================================================	
			//------------------------------------------------------------------------------ Estado Muerte
		 case EstadosPosibles.Muerte:
		 {			
		  //Codigo Entrada
			if(entrada)
			{
				entrada=false;
			}
		  //Codigo Constante
		     //Evaluando mi condicion de salida
		     //Cambiar de Estado
		  //Codigo Salida
			if(estadoActual != EstadosPosibles.Muerte)
			{
				entrada=true;
			}			
		  }break;
			//======================================================================================	
			
			
		}//Fin Switch
		
	}//Fin Maquina Estados
	
	public void PlayerEnter()
	{
		jugadorEnRango=true;
	}
	
	public void PlayerExit()
	{
		jugadorEnRango=false;
	}
	
	
	
}//Fin CLASS
