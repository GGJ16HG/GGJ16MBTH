using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Prueba))]
[CanEditMultipleObjects]
public class PruebaInspector : Editor
{
	
	SerializedProperty valorPropiedad;
	
	void OnEnable()
	{
		valorPropiedad = serializedObject.FindProperty("valor");
	}
	
	public override void OnInspectorGUI()
	{	
		serializedObject.Update();
		//aqui va mi codigo
		EditorGUILayout.IntSlider(valorPropiedad, 0,10, new GUIContent("Numero de Vidas"));
		serializedObject.ApplyModifiedProperties();
		
		/* //Forma viejita
		Prueba miTarget = (Prueba)target;
		miTarget.valor = EditorGUILayout.IntSlider("Numero de Vidas",miTarget.valor, 0 , 10);		
		//base.OnInspectorGUI();
		*/
	}	
}
