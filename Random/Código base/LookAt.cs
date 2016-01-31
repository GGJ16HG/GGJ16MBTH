using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour 
{
	public GameObject target;
	
	private bool player;
	
	// Use this for initialization
	void Start () 
	{
	  player = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(player)
		{
			gameObject.transform.LookAt(target.transform);				
		}	
	}
	
	public void PlayerEnter()
	{
		player = true;
	}
	
	public void PlayerExit()
	{
		player = false;
	}
	
}
