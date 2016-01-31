using UnityEngine;
using System.Collections;

public class Puntuacion : MonoBehaviour {

	public int puntuacion = 0;
	public TextMesh marcador;

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "incrementaPuntos");
		ActualizarMarcador ();
	}

	void incrementaPuntos(Notification notificacion)
	{	int puntos = (int)notificacion.data;
		puntuacion += puntos;
		ActualizarMarcador ();
		}

	void ActualizarMarcador()
	{
		marcador.text = puntuacion.ToString ();
		}

	// Update is called once per frame
	void Update () {
	
	}
}
