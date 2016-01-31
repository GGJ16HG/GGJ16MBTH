using UnityEngine;
using System.Collections;

public class Guardar : MonoBehaviour {
	
	public string llave_vidas = "vidas";
	
	// Use this for initialization
	void Start () {
		
		PlayerPrefs.GetInt("vidas");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
