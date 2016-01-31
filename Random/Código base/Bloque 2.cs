using UnityEngine;
using System.Collections;

public class Bloque : MonoBehaviour {

	public int PuntosMenos = 1;
	public int tempo = 5;
	private int aux;
	private bool bandera = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {	
	}

	//no se utiliza
	void controlTiempo()
	{
		aux++;
		if (aux == tempo) {
			aux = 0;
			bandera = true;
		}	
	}
	/*void OnTriggerEnter2D(Collider2D colision)
	{
		if (colision.collider.tag == "papa") {
			controlTiempo();
				if(bandera)
				{
				Debug.Log ("entra");
					NotificationCenter.DefaultCenter().PostNotification(this,"DisminuyePuntos",PuntosMenos);
					bandera = false;
				}
			
		}
	}*/
}