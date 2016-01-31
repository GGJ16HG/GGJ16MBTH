using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class GUILabel : MonoBehaviour {


	public GUIStyle estiloGUI;
	public string texto;
	public int textoX;
	public int textoY;
	public int tamanoX;
	public int tamanoY;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnGUI()
	{
		GUI.Label(new Rect(textoX, textoY, tamanoX, tamanoY), texto, estiloGUI);
	}

}
