using UnityEngine;
using System.Collections;

public class IA_Gato : MonoBehaviour {

	private bool volteaIzq = true;
	private bool volteaDer = false;
	public int daño = 25;
	public int puntos = 1;
	public float velocidad = 1f;
	public GameObject inicio;
	public GameObject final;
	public Transform gato;

	// Use this for initialization
	void Start () {
		//rigidbody2D.velocity = new Vector2(velocidad,rigidbody2D.velocity.y);
	
	}

	void FixedUpdate()
	{
		this.transform.Translate (-(velocidad * Time.deltaTime), 0f, 0f, Space.Self);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LateUpdate()
	{
		colision ();
		}

	void OnTriggerEnter2D(Collider2D colision)
	{
		if (colision.tag == "Player") {
						NotificationCenter.DefaultCenter ().PostNotification (this, "DisminuyePuntos", daño);
				}
		if (colision.tag == "fin") {
						NotificationCenter.DefaultCenter ().PostNotification (this, "incrementaPuntos", puntos);
				}
		}

	void colision()
	{
		if (transform.position.x < final.transform.position.x && !volteaDer) 
		{
				if (volteaIzq)
				{
					gato.Rotate (0f, 180f, 0f, Space.World);
					volteaIzq = false;
					volteaDer = true;
					velocidad = -velocidad;
				}
		}
		if(transform.position.x > inicio.transform.position.x && !volteaIzq)
		{
			if(volteaDer)
			{
				gato.transform.Rotate (0f,180f,0f,Space.World);
				volteaDer = false;
				volteaIzq = true;
				velocidad = -velocidad;
			}
		}

	}
}
