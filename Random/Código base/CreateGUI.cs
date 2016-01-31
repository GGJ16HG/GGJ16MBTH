using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CreateGUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		if(GUI.Button(new Rect(200, 200, 190, 20), "Juega ahora ya"))
		{
			Application.LoadLevel(1);
		}
			
	}
}
