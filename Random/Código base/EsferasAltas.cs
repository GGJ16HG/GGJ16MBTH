using UnityEngine;
using System.Collections;

public class EsferasAltas : MonoBehaviour 
{
	
	public GameObject esquinaUno;
	public GameObject esquinaDos;
	
	public GameObject areaUno;
	public GameObject areaDos;
	
	public GameObject jugador;
	
	public GameObject[] esferas;
	
	private float distanciaX;
	private float distanciaZ;

	// Use this for initialization
	void Start () 
	{
		/*
		distanciaX = areaDos.transform.position.x - areaUno.transform.position.x;
		distanciaZ = esquinaDos.transform.position.z - esquinaUno.transform.position.z;
		
		float distanciaZ2 = distanciaZ - 10;
		float distanciaX2 = distanciaX - 10;
		
		float divisionZ = distanciaZ / 5;
		float divisionX = distanciaX / 5;
		
		float inicioX = areaUno.transform.position.x + 5;
		float inicioZ = esquinaUno.transform.position.z + 5;
		
		int bola = 0;
		
		float x, z, y = areaUno.transform.position.y;
		
		for(int i=1; i<=5; i++)
		{
			for(int j=1; j<=5; j++)
			{
				
				x = distanciaX2 + (divisionX * i);
				z = distanciaZ2 + (divisionZ * j);
				
				Instantiate(esferas[bola], Vector3(x, y, z), Quaternion.identity);
				
				bola++;
				
				if(bola==3)
				{
					bola=0;
				}
			}
		}
		*/
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void CreaEsferas()
	{
		
	}
	
}
