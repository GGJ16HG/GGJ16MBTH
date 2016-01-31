using UnityEngine;
using System.Collections;

public class Idle : MonoBehaviour 
{

	public bool idling = true;
	public int rand = 0;
	
	public void Awake () 
	{
	
	}
		
	public void Update()
	{
		if (idling)
		{
			if (!animation.isPlaying)
			{
				rand  = Random.Range(0,10);
				if (0 <= rand && rand < 1)  
				{
					animation.Play("scratch");	
				}
				else if (1 <= rand && rand < 2)  
				{
					animation.Play("neckcrack");	
				}
				else if (2 <= rand && rand < 3)  
				{
					animation.Play("crossarms");	
				}
				else 
				{
					animation.Play("idle1");
				} 
			}
		}
	}
}
