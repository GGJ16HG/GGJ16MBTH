using UnityEngine;
using System.Collections;

public class acciones : MonoBehaviour {

    public float velocidad = 0.0f,
                    fsalto = 0.0f;

    private Animator animador;

    private bool enSuelo = true;
    public Transform comprobarSuelo;
    float comprobarRadio = 0.07f;
    public LayerMask mascaraSuelo;
	// Use this for initialization
    void Awake(){
        animador = GetComponent<Animator>();
    }


	void Start () {
	
	}

    void FixedUpdate(){
        enSuelo = Physics2D.OverlapCircle(comprobarSuelo.position, comprobarRadio, mascaraSuelo);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Horizontal") != 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * velocidad, GetComponent<Rigidbody2D>().velocity.y);
        }
        animador.SetFloat("velocidadx", GetComponent<Rigidbody2D>().velocity.x);
        if (enSuelo && Input.GetAxis("Jump") != 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, Input.GetAxis("Jump") * fsalto);
            //GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, Input.GetAxis("Jump") * Fsalto));
        }
    }
}
