using UnityEngine;
using System.Collections;

public class ControlUnidad : MonoBehaviour 
{
	public ControlMenu miMenu;
	private Vector3 destino;
	public AnimationClip idle, walk;
	private bool estoySeleccionado;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(estoySeleccionado)
		gameObject.GetComponent<NavMeshAgent>().destination = destino;
	
	}
	
	public void SetDestination(Vector3 p_destino)
	{
		destino = p_destino;
	}
	
	public void SetSelected(bool seleccionado)
	{
		estoySeleccionado = seleccionado;
		if(estoySeleccionado)
		{
			destino = gameObject.transform.position;
			animation.Play(walk.name);
		}
		else
		{
			animation.Play(idle.name);
		}
		
	}
	
	void OnMouseDown()
	{
		miMenu.SetSeleccionUnidad(true,gameObject);
	}
}
