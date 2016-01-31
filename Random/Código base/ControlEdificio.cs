using UnityEngine;
using System.Collections;

public class ControlEdificio : MonoBehaviour 
{
	public GameObject unidad;
	private GameObject ultimaUnidadCreada;
	public Transform spawnPointUnidad;
	public Material m_Real, m_Colocable, m_Error, m_Selected;
	public GameObject[] piezas;
	public ControlMenu miMenu;
	
	
	// Use this for initialization
	void Start () 
	{
		gameObject.collider.enabled = false;	
	}
	
	void OnMouseDown()
	{
		miMenu.SetSeleccionEdificio(true,gameObject);
	}
	
	public void CrearUnidad()
	{
		//if hay dinero, comida, etc... Switch entre tipos de unidades, varios SpawnPoints random
		ultimaUnidadCreada = (GameObject)Instantiate(unidad, spawnPointUnidad.position, spawnPointUnidad.rotation);
		ultimaUnidadCreada.GetComponent<ControlUnidad>().miMenu = miMenu;
	}
	
	public void ColocarEdificio()
	{
		gameObject.collider.enabled = true;
		SetMaterial(m_Real);
	}
	
	public void SetColocable(bool esColocable)
	{
		if(esColocable)
		{
			SetMaterial(m_Colocable);			
		}
		else
		{
			SetMaterial(m_Error);		
		}
	}
	public void SetSelected(bool estoySeleccionado)
	{
		if(estoySeleccionado)
		{
			SetMaterial(m_Selected);
		}
		else
		{
			SetMaterial(m_Real);
		}
	}
	
	private void SetMaterial(Material nuevoMaterial)
	{
		for(int i=0; i<piezas.Length; i++)
			{
				piezas[i].renderer.material = nuevoMaterial;
			}
	}
	
}
