using UnityEngine;
using System.Collections;

public class ControlLevel : MonoBehaviour 
{
	/*
	 * Items necesarios para ritual:
	 * - Agua Bendita
	 * - Biblia
	 * - Cruz
	 * - Rosario
	 */

	//Item: agua bendita
	public GameObject aguaBendita;
	public GameObject[] posicionesAguaBendita;

	//Item: Biblia
	public GameObject biblia;
	public GameObject[] posicionesBiblia;

	//Item: Cruz
	public GameObject cruz;
	public GameObject[] posicionesCruz;

	//Item: Rosario
	public GameObject rosario;
	public GameObject[] posicionesRosario;

	/*
	 * Items potenciadores:
	 * - Capa
	 * - Pollo
	 * - Pluma
	 * - Vial
	 */

	//Item capa
	public GameObject capa;
	public GameObject[] posicionesCapa;
	public int maxCapa;

	//Item pollo
	public GameObject pollo;
	public GameObject[] posicionesPollo;
	public int maxPollo;

	//Item pluma
	public GameObject pluma;
	public GameObject[] posicionesPluma;
	public int maxPluma;

	//Item vial
	public GameObject vial;
	public GameObject[] posicionesVial;
	public int maxVial;

	//Posicionador de items para ritual
	void posicionarItemsRitual()
	{
		//Item agua bendita
		if(aguaBendita != null && posicionesAguaBendita.Length>0)
		{
			Debug.Log("Valor no nulo y con valores");
			if(posicionesAguaBendita.Length == 1) 
			{
				if(posicionesAguaBendita[0] != null)
				{
					Instantiate(aguaBendita,posicionesAguaBendita[0].transform.position, Quaternion.identity);
				}
			} 
			else 
			{
				//Se comprueba que no existan elementos nulos
				int nulo = 0;

				for (int i = 0; i < posicionesAguaBendita.Length; i++) 
				{
					if(posicionesAguaBendita[i] == null)
					{
						nulo++;
					}
				}

				Debug.Log("Valor nulo: "+nulo);

				if(nulo != posicionesAguaBendita.Length)
				{
					boolean existe = false;
					int random = 0;
					while(existe == false)
					{
						random = Random.Range(0,posicionesAguaBendita.Length-1);
						if(posicionesAguaBendita[random] != null) 
						{
							Debug.Log("Ya hay");
							Instantiate(aguaBendita,posicionesAguaBendita[random].transform.position, Quaternion.identity);
							existe = true;
						}
					}
				}
			}
		}
			
	}

	// Use this for initialization
	void Start () 
	{
		posicionarItemsRitual();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
