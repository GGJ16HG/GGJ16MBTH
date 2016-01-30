using UnityEngine;
using System.Collections;


public class ControlJugador : MonoBehaviour 
{
	
	//Esquinas del juego
	public GameObject esquinaUno;
	public GameObject esquinaDos;
	
	//Ubicar al jugador
	public GameObject posicionJugador;
	
	//LevelManager
	private GameObject levelManager;
	
	private int tiempo;
	
	public GameObject meta;
	
	public int nivelCarga;
	
	int cuenta;
	
	// Use this for initialization
	void Start () 
	{
		levelManager = GameObject.FindGameObjectWithTag("LevelManager");
		PosicionarJugador();
		cuenta = 0;
		tiempo = 0;
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		Carril();
	
	}
	
	void Update()
	{
		tiempo++;
		
		Debug.Log(tiempo);
		
		if(transform.position.x > meta.transform.position.x || tiempo>700)
		{
			Application.LoadLevel(nivelCarga);
		}
	}
	
	void PosicionarJugador()
	{
		transform.position = new Vector3(posicionJugador.transform.position.x,
										 posicionJugador.transform.position.y,
										 posicionJugador.transform.position.z);
	}
	
	void OnTriggerEnter(Collider objetoColision)
	{
		if(objetoColision.gameObject.CompareTag("Amarillo"))
		{
			Debug.Log("Amarillo");
			levelManager.GetComponent<ControlNivel>().AumentaPuntaje(5);
		}
		
		if(objetoColision.gameObject.CompareTag("Azul"))
		{
			Debug.Log("Azul");
			levelManager.GetComponent<ControlNivel>().AumentaPuntaje(10);
		}
		
		if(objetoColision.gameObject.CompareTag("Verde"))
		{
			Debug.Log("Verde");
		}
		
		if(objetoColision.gameObject.CompareTag("Roja"))
		{
			Debug.Log("Roja");
			levelManager.GetComponent<ControlNivel>().DisminuyePuntaje(5);
		}
		
		if(objetoColision.gameObject.CompareTag("Chocolate"))
		{
			Debug.Log("Chocolate");
			levelManager.GetComponent<ControlNivel>().DisminuyePuntaje(1);
		}
		
		if(objetoColision.gameObject.CompareTag("Hojuelas"))
		{
			Debug.Log("Hojuelas");
			levelManager.GetComponent<ControlNivel>().DisminuyePuntaje(2);
		}
		
		if(objetoColision.gameObject.CompareTag("PopCorns"))
		{
			Debug.Log("PopCorns");
			levelManager.GetComponent<ControlNivel>().DisminuyePuntaje(5);
			
		}
		
		if(objetoColision.gameObject.CompareTag("Rueditas"))
		{
			Debug.Log("Rueditas");
			levelManager.GetComponent<ControlNivel>().DisminuyePuntaje(10);
			
		}
	}
	
	void Carril()
	{
		// X de las esquinas
		
		//Esquina uno
		
		if(transform.position.x < esquinaUno.transform.position.x)
		{
			transform.position = new Vector3(esquinaUno.transform.position.x,
											 transform.position.y, 
											 transform.position.z);
		}
		
		//Esquina dos
		if(transform.position.x > esquinaDos.transform.position.x)
		{
			transform.position = new Vector3(esquinaDos.transform.position.x,
											 transform.position.y, 
											 transform.position.z);
		}
		
		// Z de las esquinas
		
		//Esquina uno
		
		if(transform.position.z < esquinaUno.transform.position.z)
		{
			transform.position = new Vector3(transform.position.x,
											 transform.position.y, 
											 esquinaUno.transform.position.z);
		}
		
		//Esquina dos
		if(transform.position.z > esquinaDos.transform.position.z)
		{
			transform.position = new Vector3(transform.position.x,
											 transform.position.y, 
											 esquinaDos.transform.position.z);
		}
		
	}
}
