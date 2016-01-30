using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class ReemplazarConPrefab : ScriptableObject 
{
	[MenuItem("Ville/Reemplazar con un Prefab")]
	
	public static void Reemplazar()
	{
		GameObject prefab = new List<Object>(Selection.GetFiltered(typeof(GameObject), SelectionMode.Assets)).
																			Find ( x => {return AssetDatabase.IsMainAsset(x);}) as GameObject;
		
		if(prefab == null)
		{
			return;
		}
		
		Object[] objetosEnEscena = Selection.GetFiltered(typeof(Transform), SelectionMode.ExcludePrefab);
		Undo.RegisterUndo(objetosEnEscena, "Reemplazar Seleccion con el Prefab");
		//Los voy a reemplazar
		foreach(Transform t in objetosEnEscena)
		{
			GameObject prefabInstanciado = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
			
			prefabInstanciado.transform.parent = t.parent;
			prefabInstanciado.transform.position = t.localPosition;
			prefabInstanciado.transform.rotation = t.localRotation;
			prefabInstanciado.transform.localScale = t.localScale;
			
			DestroyImmediate(t.gameObject);			
		}				
	}
}
