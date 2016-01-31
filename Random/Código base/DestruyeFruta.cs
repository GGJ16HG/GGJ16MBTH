using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class DestruyeFruta : MonoBehaviour {
	
	public GameObject jugador;
	private GameObject levelManager;
	private float restarPuntaje;
	private float sumarPuntaje;
	public AudioClip mordida;
	
	void Start()
	{
		levelManager = GameObject.FindGameObjectWithTag("LevelManager");
		this.sumarPuntaje = levelManager.GetComponent<LevelManager>().sumarVida;
		this.restarPuntaje = levelManager.GetComponent<LevelManager>().quitarVida;
	}
	
	void OnTriggerEnter(Collider Jugador)
	{
		if(jugador.gameObject.CompareTag("Player"))
		{
			Debug.Log("Me chocó el jugador que juega");
			if(this.gameObject.CompareTag("FrutaMala"))
			{
				levelManager.GetComponent<LevelManager>().DisminuyePuntaje(this.restarPuntaje);
				Debug.Log("Soy un villano");
			}
			else if(this.gameObject.CompareTag("FrutaBuena"))
			{
				levelManager.GetComponent<LevelManager>().AumentaPuntaje(this.sumarPuntaje);
				Debug.Log("Soy una fruta buena");
			}
			audio.PlayOneShot(mordida);
			Destroy(gameObject,2);
		}
		
		
	}
}
