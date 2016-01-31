using UnityEngine;
using System.Collections;

public class ControlFabrica : MonoBehaviour {
	
	public GameObject[] plataformas;	
	public Transform inicioBanda;
	public float velocidad;
	
	
	private GameObject ultimaPlataforma;	
	
	void Start () 
	{
		CrearPlataforma();
	}
		
	void Update () 
	{
		if(ultimaPlataforma.transform.position.x<inicioBanda.position.x)
		{
			CrearPlataforma();
		}	
	}
	
	private void CrearPlataforma()
	{
		ultimaPlataforma = (GameObject)Instantiate(plataformas[Random.Range(0,plataformas.Length)], transform.position, transform.rotation);
		ultimaPlataforma.GetComponent<ControlPlataforma>().miFabrica = gameObject.GetComponent<ControlFabrica>();
	}
	
}
