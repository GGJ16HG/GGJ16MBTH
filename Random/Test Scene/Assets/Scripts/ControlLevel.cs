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

				if(nulo != posicionesAguaBendita.Length)
				{
					bool existe = false;
					int random = 0;
					while(existe == false)
					{
						random = Random.Range(0,posicionesAguaBendita.Length-1);
						if(posicionesAguaBendita[random] != null) 
						{
							Instantiate(aguaBendita,posicionesAguaBendita[random].transform.position, Quaternion.identity);
							existe = true;
						}
					}
				}
			}
		}

		//Item biblia
		if(biblia != null && posicionesBiblia.Length>0)
		{
			Debug.Log("Valor no nulo y con valores");
			if(posicionesBiblia.Length == 1) 
			{
				if(posicionesBiblia[0] != null)
				{
					Instantiate(biblia,posicionesBiblia[0].transform.position, Quaternion.identity);
				}
			} 
			else 
			{
				//Se comprueba que no existan elementos nulos
				int nulo = 0;

				for (int i = 0; i < posicionesBiblia.Length; i++) 
				{
					if(posicionesBiblia[i] == null)
					{
						nulo++;
					}
				}

				if(nulo != posicionesBiblia.Length)
				{
					bool existe = false;
					int random = 0;
					while(existe == false)
					{
						random = Random.Range(0,posicionesBiblia.Length-1);
						if(posicionesBiblia[random] != null) 
						{
							Instantiate(biblia,posicionesBiblia[random].transform.position, Quaternion.identity);
							existe = true;
						}
					}
				}
			}
		}

		//Item cruz
		if(cruz != null && posicionesCruz.Length>0)
		{
			Debug.Log("Valor no nulo y con valores");
			if(posicionesCruz.Length == 1) 
			{
				if(posicionesCruz[0] != null)
				{
					Instantiate(cruz,posicionesCruz[0].transform.position, Quaternion.identity);
				}
			} 
			else 
			{
				//Se comprueba que no existan elementos nulos
				int nulo = 0;

				for (int i = 0; i < posicionesCruz.Length; i++) 
				{
					if(posicionesCruz[i] == null)
					{
						nulo++;
					}
				}

				if(nulo != posicionesCruz.Length)
				{
					bool existe = false;
					int random = 0;
					while(existe == false)
					{
						random = Random.Range(0,posicionesCruz.Length-1);
						if(posicionesCruz[random] != null) 
						{
							Instantiate(cruz,posicionesCruz[random].transform.position, Quaternion.identity);
							existe = true;
						}
					}
				}
			}
		}

		//Item rosario
		if(rosario != null && posicionesRosario.Length>0)
		{
			Debug.Log("Valor no nulo y con valores");
			if(posicionesCruz.Length == 1) 
			{
				if(posicionesCruz[0] != null)
				{
					Instantiate(rosario,posicionesRosario[0].transform.position, Quaternion.identity);
				}
			} 
			else 
			{
				//Se comprueba que no existan elementos nulos
				int nulo = 0;

				for (int i = 0; i < posicionesRosario.Length; i++) 
				{
					if(posicionesRosario[i] == null)
					{
						nulo++;
					}
				}

				if(nulo != posicionesRosario.Length)
				{
					bool existe = false;
					int random = 0;
					while(existe == false)
					{
						random = Random.Range(0,posicionesRosario.Length-1);
						if(posicionesCruz[random] != null) 
						{
							Instantiate(rosario,posicionesRosario[random].transform.position, Quaternion.identity);
							existe = true;
						}
					}
				}
			}
		}
			
	}

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
