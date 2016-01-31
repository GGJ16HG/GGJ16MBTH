using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System;

[CustomEditor( typeof (Path))]
public class PathInspector : Editor 
{

	private SerializedObject m_Object;
	private SerializedProperty m_Waypoints;
	
	
	public void OnEnable()
	{
		
		m_Object = new SerializedObject(target);
		m_Waypoints = m_Object.FindProperty(sRutaArreglo);
	}
	
	private static string sRutaArreglo = "waypoints";
	private static string sInfoArreglo = "waypoints.Array.data[{0}]";
	
	
	private Transform[] GetWaypointArray()
	{
		int arraySize = m_Waypoints.arraySize;
		Transform[] transformArray = new Transform[arraySize];
		
		for(int i = 0; i< arraySize; i++)
		{
			transformArray[i] = m_Object.FindProperty(string.Format(sInfoArreglo, i)).objectReferenceValue as Transform;
		}
		
		return transformArray;
	}
	
	private void SetWayPoint(int index, Transform waypoint)
	{
		m_Object.FindProperty(string.Format(sInfoArreglo, index)).objectReferenceValue = waypoint;
	}
	
	private Transform GetWayPointAtIndex(int index)
	{
		return m_Object.FindProperty(string.Format(sInfoArreglo, index)).objectReferenceValue as Transform;		
	}
	
	private void RemoveWaypointAtIndex(int index)
	{
		for(int i=index; i<m_Waypoints.arraySize -1; i++)
		{
			SetWayPoint(i, GetWayPointAtIndex(i+1));
		}
		m_Waypoints.arraySize--;
	}
	
	private bool CanMoveUp(int index)
	{
		return index >= 1;
	}
	
	private bool CanMoveDown(int index)
	{
		return index < m_Waypoints.arraySize - 1;
	}
	
	private void SwapWaypoints(int index1, int index2)
	{
		Transform waypointTemp = GetWayPointAtIndex(index1);
		SetWayPoint(index1, GetWayPointAtIndex(index2));
		SetWayPoint(index2, waypointTemp);
	}
	
	
	public override void OnInspectorGUI()
	{
		m_Object.Update();
		
		GUILayout.Label("Waypoints", EditorStyles.boldLabel);
					
		Transform[] waypoints = GetWaypointArray();
		
		for(int i = 0; i < waypoints.Length; i++)
		{
			GUILayout.BeginHorizontal();
			Transform result = EditorGUILayout.ObjectField(waypoints[i], typeof(Transform), true) as Transform;
			
			if(GUI.changed)
			{
				SetWayPoint(i, result);
			}
			
			
			bool oldEnable = GUI.enabled;			
			
			GUI.enabled &= CanMoveUp(i);
			if(GUILayout.Button("˄", GUILayout.Width(25)))
			{
				//Mover Objeto Hacia Arriba
				SwapWaypoints(i, i-1);
			}
			GUI.enabled = oldEnable && CanMoveDown(i);
			if(GUILayout.Button("˅", GUILayout.Width(25)))
			{
				//Mover Objeto Hacia Abajo
				SwapWaypoints(i, i+1);
			}
			
			GUI.enabled = oldEnable;
			if(GUILayout.Button("x", GUILayout.Width(50)))
			{
				//Eliminar El Objeto
				RemoveWaypointAtIndex(i);
			}			
			
			GUILayout.EndHorizontal();
		}
		
		
		DropAreaGUI();
		
		m_Object.ApplyModifiedProperties();
		
	}
	
	private void AddWaypoint(Transform waypoint)
	{
		m_Waypoints.arraySize++;
		SetWayPoint(m_Waypoints.arraySize - 1, waypoint);
	}
	
	
	private void DropAreaGUI()
	{
		Event evt = Event.current;
		
		Rect dropArea = GUILayoutUtility.GetRect(0,50, GUILayout.ExpandWidth(true));
		GUI.Box (dropArea, "Agregar Waypoint");
		switch(evt.type)
		{
			case EventType.DragUpdated:
			case EventType.DragPerform:
				if(!dropArea.Contains(evt.mousePosition))
				break;
				
				DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
				if(evt.type == EventType.DragPerform)
				{
					DragAndDrop.AcceptDrag();
					foreach(UnityEngine.Object draggedObject in DragAndDrop.objectReferences)
					{
						GameObject go = draggedObject as GameObject;
						if(!go)
							continue;
					
						Transform waypoint = go.transform;
						if(!waypoint)
							continue;
						
						AddWaypoint(waypoint);
					}
				}
			
				break;
		}
		
		
	}
	
}
