using UnityEngine;
using System.Collections;
using UnityEditor;


public class VentanaEditor : EditorWindow
{
	[MenuItem("Ville/Ventana")]
	static void Init()
	{
		VentanaEditor window = (VentanaEditor)EditorWindow.GetWindow(typeof(VentanaEditor),false,"Ventanita");
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
		
	}
	
	void OnSceneGUI()
	{
		
	}
	
}
