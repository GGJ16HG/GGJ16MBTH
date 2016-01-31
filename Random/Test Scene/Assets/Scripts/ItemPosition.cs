using UnityEngine;
using System.Collections;

public class ItemPosition : MonoBehaviour 
{

	private int position;

	public void setPosition(int pos)
	{
		this.position = pos;
	}

	public int getPosition()
	{
		return this.position;
	}
}
