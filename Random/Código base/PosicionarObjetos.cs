using UnityEngine;
using System.Collections;
using UnityEditor;

public class PosicionarObjetos : EditorWindow
{
	private GameObject objeto;
	private Texture2D logo;
	private bool negroBlanco;
	
	[MenuItem("Ville/Posicionar Objetos")]
	static void Init()
	{
		PosicionarObjetos window = 
			(PosicionarObjetos)EditorWindow.GetWindow(typeof(PosicionarObjetos),false,"Posiciona");
	}
	
	void OnInspectorUpdate()
	{
		Repaint();
	}
	
	void OnEnable()
	{
		logo = (Texture2D)Resources.Load("Negro");
	}
	
	void OnGUI()
	{
		if(GUI.Button(new Rect(10,10,80,80),logo))
		{
			if(negroBlanco)
			{
				logo = (Texture2D)Resources.Load("Negro");
			}
			else
			{
				logo = (Texture2D)Resources.Load("Blanco");
			}
			negroBlanco = !negroBlanco;
			
			if(objeto)
			{
				if(Selection.activeGameObject)
				{
					objeto.transform.position = Selection.activeGameObject.transform.position;
				}				
			}
		}
		
		objeto = (GameObject) EditorGUI.ObjectField(new Rect(95,10,position.width - 105 ,16), objeto, typeof(GameObject), true);		
	}
	
}
