using UnityEngine;
using System.Collections;

public class Prueba : MonoBehaviour 
{
	[SerializeField]
	private int valor;
	
	public int Valor
	{
		get{ return valor;}
		set{ Mathf.Clamp(valor,0,10);}
	}
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	
	}
}
