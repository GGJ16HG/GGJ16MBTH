using UnityEngine;
using System.Collections;

public class Generador : MonoBehaviour {

	public GameObject[] obj;
	public float tiempoMin = 20f;
	public float tiempoMax = 30f;
	int tiempo;

	// Use this for initialization
	void Start () 
	{
		tiempo = 0;
		NotificationCenter.DefaultCenter().AddObserver(this,"EmpiezaCorrer");
	
	}

	void EmpiezaCorrer (Notification notificacion)
	{
		if(tiempo%7==0)
		{
			Generar();
			Debug.Log("Empieza a correr: " + tiempo);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		tiempo++;
	}

	void Generar ()
	{
		Instantiate (obj [Random.Range (0, obj.Length)], transform.position, Quaternion.identity);
		Invoke ("Generar", Random.Range (tiempoMin, tiempoMax));	      
	}
}
