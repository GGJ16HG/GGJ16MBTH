using UnityEngine;
using System.Collections;

public class ItemPosition : MonoBehaviour 
{

	private int position = -1;

	public void setOcupado(int position)
	{
		this.position = position;
	}

	public int getOcupado()
	{
		return this.position;
	}
}
