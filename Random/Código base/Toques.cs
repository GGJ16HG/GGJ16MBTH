using UnityEngine;
using System.Collections;

public class Toques : MonoBehaviour 
{
	public Material m_off, m_on;
	private RaycastHit infoRayo;
	

	// Use this for initialization
	void Start () 
	{		
		gameObject.renderer.material = m_off;
	}
	
	// Update is called once per frame
	void Update () 
	{	
		/*
		Ray rayoMouse = Camera.mainCamera.ScreenPointToRay(new Vector3(Input.mousePosition.x,Input.mousePosition.y,0));
		if(Physics.Raycast(rayoMouse, out infoRayo))
		{	//OnMouseEnter()
			
			gameObject.renderer.material = m_on;			
		}
		else
		{	//OnMouseExit()
			gameObject.renderer.material = m_off;
		}
		*/
		
		
		if(Input.touchCount>0)
		{
			for(int i=0; i<Input.touchCount; i++)
			{
				Ray rayo = Camera.mainCamera.ScreenPointToRay(new Vector3(Input.touches[i].position.x,Input.touches[i].position.y,0));
				//if(collider.Raycast(rayo, out infoRayo, 1000))
				if(Physics.Raycast(rayo, out infoRayo)) 				
				{
					//if(infoRayo.collider.gameObject.GetInstanceID() == gameObject.GetInstanceID())
					{
						//Esta tocando ESTE gameobject, pero que esta haciendo?						
						if(Input.touches[i].phase == TouchPhase.Began)
						{
							//Esto es similar a un input.GetMouseButtonDown(i)
							infoRayo.collider.gameObject.SendMessage("OnMouseDown",SendMessageOptions.DontRequireReceiver);
							//gameObject.renderer.material = m_on;
						}
						if(Input.touches[i].phase == TouchPhase.Ended || Input.touches[i].phase == TouchPhase.Canceled)
						{
							//Esto es similar a un input.GetMouseButtonUp(i)
							infoRayo.collider.gameObject.SendMessage("OnMouseUp",SendMessageOptions.DontRequireReceiver);
							//gameObject.renderer.material = m_off;
						}
						
						if(Input.touches[i].phase == TouchPhase.Moved || Input.touches[i].phase == TouchPhase.Stationary)
						{
							infoRayo.collider.gameObject.SendMessage("OnMouse",SendMessageOptions.DontRequireReceiver);
							//Esto es similar a un input.GetMouseButton(i)
						}
					}
				}
			}
		}
		
		//Input.touches[0].fingerId		
	}
	
	/*
	void OnMouseDown()
	{
		gameObject.renderer.material = m_on;
	}
	
	void OnMouseUp()
	{
		gameObject.renderer.material = m_off;
	}
	*/
	
	
	
	
}
