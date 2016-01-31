using UnityEngine;
using System.Collections;

public class Vida : MonoBehaviour {

	public int puntuacion = 100;
	public TextMesh marcador;

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "DisminuyePuntos");
		ActualizarMarcador ();
	}

	void DisminuyePuntos(Notification notificacion)
	{
		int daño = (int)notificacion.data;
		puntuacion -= daño;
		ActualizarMarcador ();
	}

	void ActualizarMarcador()
	{
		marcador.text = puntuacion.ToString ();
		}

	// Update is called once per frame
	void Update () {

		if (puntuacion == 0) {
						puntuacion = 0;
						Debug.Break ();
				}

	
	}
}
