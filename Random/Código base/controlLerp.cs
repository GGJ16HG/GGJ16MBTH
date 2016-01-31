using UnityEngine;
using System.Collections;

public class controlLerp : MonoBehaviour 
{
	public Transform puntoA, puntoB;
	private float porcentaje;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position = Vector3.Lerp(puntoA.position, puntoB.position, porcentaje);
		transform.rotation = Quaternion.Lerp(puntoA.rotation, puntoB.rotation, porcentaje);
		transform.localScale = Vector3.Lerp(puntoA.localScale, puntoB.localScale, porcentaje);
	
	}
	
	void OnGUI()
	{
		porcentaje = GUI.HorizontalSlider( new Rect(10,10,Screen.width -20, 20), porcentaje, 0,1);
	}
	
	
}
