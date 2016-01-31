using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	public int PuntosIncremento = 3;

	int tiempoBase;

	// Use this for initialization
	void Start () 
	{
		tiempoBase = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		CalculoTiempo();
	}

	void CalculoTiempo()
	{
		tiempoBase++;
		if (tiempoBase == 200)
		{
			Debug.Log("Me destruyo a mi mismo");
			Destroy (gameObject);
		}

	}

	void OnTriggerEnter2D(Collider2D colision)
	{
		if(colision.tag=="Player")
			NotificationCenter.DefaultCenter().PostNotification(this,"incrementaPuntos",PuntosIncremento);
		Destroy (gameObject);

	}
}
