using UnityEngine;
using System.Collections;

public class TestMove : MonoBehaviour {

	public float speed = 10.0F; //Velocidad de movimiento
	public float rotationSpeed = 100.0F; //Velocidad de rotación
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate(0, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
		transform.Translate( Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime , 0, 0);
	}
}
