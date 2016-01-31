using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

public class ModificadorParedes : EditorWindow 
{	
	private Texture2D TexturaPared;

	
	[MenuItem("Personalizado/Modificar paredes")]
	static void Init()
	{
		ModificadorParedes window = (ModificadorParedes)EditorWindow.GetWindow(typeof(ModificadorParedes),false,"Paredes");
		//Tamaño mínimo: 230 x 200
		window.minSize = new Vector2(230, 200);
		//Tamaño máximo: 310 x 685
		window.maxSize = new Vector2(310, 685);
	}
	
	void OnInspectorUpdate()
	{
		Repaint();	
	}
	
	void OnEnable()
	{
		
	}
	
	void OnGUI()
	{
		
		//Textura para pared
		GUI.Label(new Rect(10,10,150,50),"Textura para paredes", EditorStyles.boldLabel);
		//Tamaño máximo: 60X60
		TexturaPared = (Texture2D) EditorGUI.ObjectField(new Rect(position.width - 70, 10 ,60, 60), TexturaPared, typeof(Texture2D), true);	
		//Debug.Log("Window width: " + position.width + " Window height: "+position.height);
		
		if(TexturaPared == null)
		{
			//GUI.Label(new Rect(10,1000,10,500),"No existe textura.");
			//Debug.Log("Textura");
		}
		else
		{
			//GUI.Label(new Rect(10,40,1000,500),TexturaPared.ToString());
			//Debug.Log(TexturaPared.name);
		}
		
	}
	
	void OnSceneGUI()
	{
		
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
