using UnityEngine;
using System.Collections;

public class LerpBrazo : MonoBehaviour {
	
	public Transform miBrazo, miMano;
	public Material matLerp, matA,matB;
	
	public Transform posA_Brazo, posA_Mano;
	public Transform posB_Brazo, posB_Mano;
	
	private float porcentaje;

	void Update () 
	{
		miBrazo.rotation = Quaternion.Lerp(posA_Brazo.rotation, posB_Brazo.rotation, porcentaje);
		miMano.rotation = Quaternion.Lerp(posA_Mano.rotation, posB_Mano.rotation, porcentaje);
	    matLerp.color = Color.Lerp(matA.color, matB.color, porcentaje);
	}
	
	void OnGUI()
	{
		porcentaje = GUI.HorizontalSlider( new Rect(10,10,Screen.width -20, 20), porcentaje, 0,1);
		
		GUI.Label( new Rect (20,20,200,20), "InverseLerp: " + Mathf.InverseLerp(-1.0f,1.0f, Input.GetAxis("Horizontal")));
		GUI.Label( new Rect (20,40,100,20), "Lerp: " + Mathf.Lerp(40,250,porcentaje));
		
		
	}
}
