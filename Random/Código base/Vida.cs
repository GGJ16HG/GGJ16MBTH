using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Vida : MonoBehaviour {

	public int puntuacion = 100;
	public TextMesh marcador;
	public GameObject jugador;
	public GameObject cruz;
	public GUIStyle estiloGUI;

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "DisminuyePuntos");
		ActualizarMarcador ();
		jugador.SetActive(true);
		cruz.SetActive(false);

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

		if (puntuacion == 0) 
		{

			Debug.Log("Perdi");
			puntuacion = 0;

			cruz.transform.position = new Vector3(jugador.transform.position.x,
			                                 0.0f,
			                                 jugador.transform.position.z);
			jugador.SetActive(false);
			cruz.SetActive(true);

		}

	}

	void OnGUI()
	{
		if (puntuacion == 0) 
		{
			GUI.Label(new Rect(400.0f,100.0f,100.0f,100.0f), "Game Over", estiloGUI);
			//Debug.Break();
			//Se cambia la papa por una cruz
			if(GUI.Button(new Rect(600.0f,300.0f,100.0f,100.0f), "¿Seguir Jugando?", estiloGUI))
			{
				Debug.Log("Haz seleccionado seguir jugando.");
				Application.LoadLevel(2);
			}
		}

	}
}
