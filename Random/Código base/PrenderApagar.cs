using UnityEngine;
using System.Collections;
using UnityEditor;

public class PrenderApagar : EditorWindow 
{
	[MenuItem("Ville/OnOff %#e")]
	public static void OnOff()
	{
		Object[] seleccion = Selection.GetFiltered(typeof(GameObject), SelectionMode.Editable | SelectionMode.TopLevel);
		for(int i = 0 ; i <seleccion.Length; i++)
		{
			GameObject go = seleccion[i] as GameObject;
			if(go == null){continue;}			
			go.SetActive(!(go.activeSelf));			
			
		}
	}

}
