using UnityEngine;
using System.Collections;

public class ControlPosicion : MonoBehaviour 
{
	private bool ocupado = false;

	public void setOcupado(bool ocupado)
	{
		this.ocupado = ocupado;
	}

	public bool getOcupado()
	{
		return this.ocupado;
	}
}
