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
			if(posicionesAguaBendita.Length == 1) 
			{
				if(posicionesAguaBendita[0] != null)
				{
					Instantiate(aguaBendita,posicionesAguaBendita[0].transform.position, Quaternion.identity);
					posicionesAguaBendita[0].GetComponent<ControlPosicion>().setOcupado(true);
					aguaBendita.GetComponent<ItemPosition>().setPosition(0);
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
							posicionesAguaBendita[random].GetComponent<ControlPosicion>().setOcupado(true);
							aguaBendita.GetComponent<ItemPosition>().setPosition(random);
							existe = true;
						}
					}
				}
			}
		}

		//Item biblia
		if(biblia != null && posicionesBiblia.Length>0)
		{
			if(posicionesBiblia.Length == 1) 
			{
				if(posicionesBiblia[0] != null)
				{
					Instantiate(biblia,posicionesBiblia[0].transform.position, Quaternion.identity);
					posicionesBiblia[0].GetComponent<ControlPosicion>().setOcupado(true);
					biblia.GetComponent<ItemPosition>().setPosition(0);
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
							posicionesBiblia[random].GetComponent<ControlPosicion>().setOcupado(true);
							biblia.GetComponent<ItemPosition>().setPosition(random);
							existe = true;
						}
					}
				}
			}
		}

		//Item cruz
		if(cruz != null && posicionesCruz.Length>0)
		{
			if(posicionesCruz.Length == 1) 
			{
				if(posicionesCruz[0] != null)
				{
					Instantiate(cruz,posicionesCruz[0].transform.position, Quaternion.identity);
					posicionesCruz[0].GetComponent<ControlPosicion>().setOcupado(true);
					cruz.GetComponent<ItemPosition>().setPosition(0);
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
							posicionesCruz[random].GetComponent<ControlPosicion>().setOcupado(true);
							cruz.GetComponent<ItemPosition>().setPosition(random);
							existe = true;
						}
					}
				}
			}
		}

		//Item rosario
		if(rosario != null && posicionesRosario.Length>0)
		{
			if(posicionesCruz.Length == 1) 
			{
				if(posicionesCruz[0] != null)
				{
					Instantiate(rosario,posicionesRosario[0].transform.position, Quaternion.identity);
					posicionesRosario[0].GetComponent<ControlPosicion>().setOcupado(true);
					rosario.GetComponent<ItemPosition>().setPosition(0);
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
							posicionesRosario[random].GetComponent<ControlPosicion>().setOcupado(true);
							rosario.GetComponent<ItemPosition>().setPosition(random);
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
	 * - Bota
	 * - Vial
	 */

	//Item pollo
	public GameObject pollo;
	public GameObject[] posicionesPollo;
	public int maxPolloFijo = 1;
	public int maxPollo = 2;

	//Item Bota
	public GameObject bota;
	public GameObject[] posicionesBota;
	public int maxBotaFijo = 2;
	public int maxBota = 4;

	//Item vial
	public GameObject vial;
	public GameObject[] posicionesVial;
	public int maxVialFijo = 1;
	public int maxVial = 2;

	//Contadores
	private int polloVariable = 0;
	private int botaVariable = 0;
	private int vialVariable = 0;
	private int capaVariable = 0;

	void posicionarItemsPotenciadores()
	{
		int contador = 0;
		int referencia = 0;
		//Item pollo
		if(pollo != null && posicionesPollo.Length > 0) 
		{
			if(posicionesPollo.Length < maxPolloFijo) 
			{
				referencia = posicionesPollo.Length;
			} 
			else 
			{
				referencia = maxPolloFijo;
			}

			while(contador < referencia)
			{
				if(posicionesPollo[contador] != null) 
				{
					Instantiate(pollo,posicionesPollo[contador].transform.position, Quaternion.identity);
					posicionesPollo[contador].GetComponent<ControlPosicion>().setOcupado(true);
					pollo.GetComponent<ItemPosition>().setPosition(contador);
					polloVariable++;
				}
				contador++;
			}
		}	

		contador = 0;
		//Item bota
		if(bota != null && posicionesBota.Length > 0) 
		{
			if(posicionesBota.Length < maxBotaFijo) 
			{
				referencia = posicionesBota.Length;
			} 
			else 
			{
				referencia = maxBotaFijo;
			}

			while(contador < referencia)
			{
				if(posicionesBota[contador] != null) 
				{
					Instantiate(bota,posicionesBota[contador].transform.position, Quaternion.identity);
					posicionesBota[contador].GetComponent<ControlPosicion>().setOcupado(true);
					bota.GetComponent<ItemPosition>().setPosition(contador);
					botaVariable++;
				}
				contador++;
			}
		}

		contador = 0;
		//Item vial
		if(vial != null && posicionesVial.Length > 0) 
		{
			if(posicionesVial.Length < maxVialFijo) 
			{
				referencia = posicionesVial.Length;
			} 
			else 
			{
				referencia = maxVialFijo;
			}

			while(contador < referencia)
			{
				if(posicionesVial[contador] != null) 
				{
					Instantiate(vial,posicionesVial[contador].transform.position, Quaternion.identity);
					posicionesVial[contador].GetComponent<ControlPosicion>().setOcupado(true);
					vial.GetComponent<ItemPosition>().setPosition(contador);
					vialVariable++;
				}
				contador++;
			}
		}
	}
		
	// Use this for initialization
	void Start () 
	{
		//Se inicializa a cero al momento de iniciar la ejecución de la escena.
		polloVariable = 0;
		botaVariable = 0;
		vialVariable = 0;
		capaVariable = 0;
		posicionarItemsRitual();
		posicionarItemsPotenciadores();
	}

	//Item capa
	public GameObject capa;
	public GameObject[] posicionesCapa;
	public int maxCapa = 1;

	//Contador de tiempo
	private int tiempoBase;
	
	// Update is called once per frame
	void Update() 
	{
		tiempoBase = (int)Time.time;

		if(tiempoBase % 10 == 0)
		{
			int random = Random.Range(0,100);

			//Se revisan probabilidades
			if(random >= 0 && random <5)
			{
				//Pocion
				//vialVariable = 0;
				if(this.vialVariable < this.maxVial)
				{
					Debug.Log("Aun hay espacio Vial");

					for(int i = 0; i < posicionesVial.Length; i++) 
					{
						if (!posicionesVial [i].GetComponent<ControlPosicion> ().getOcupado ()) 
						{
							Debug.Log ("Puede Ser Ocupado");
							Instantiate(vial,posicionesVial[i].transform.position, Quaternion.identity);
							posicionesVial[i].GetComponent<ControlPosicion>().setOcupado(true);
							vial.GetComponent<ItemPosition>().setPosition(i);
							vialVariable++;
							break;
						} 
						else 
						{
							Debug.Log ("NO!!! Ser Ocupado");
						}
					}
				}
			}
			if(random >= 25 && random <30)
			{
				//Pollo
				//polloVariable = 0;
				if(this.polloVariable < this.maxPollo)
				{
					Debug.Log("Aun hay espacio Pollo");

					for(int i = 0; i < posicionesPollo.Length; i++) 
					{
						if(!posicionesPollo[i].GetComponent<ControlPosicion>().getOcupado())
						{
							Debug.Log("Puede Ser Ocupado");
							Instantiate(pollo,posicionesPollo[i].transform.position, Quaternion.identity);
							posicionesPollo[i].GetComponent<ControlPosicion>().setOcupado(true);
							pollo.GetComponent<ItemPosition>().setPosition(i);
							polloVariable++;
							break;
						}
						else 
						{
							Debug.Log ("NO!!! Ser Ocupado");
						}
					}
				}
			}
			if(random >= 75 && random <85)
			{
				//Bota
				//botaVariable = 0;
				if(this.botaVariable < this.maxBota)
				{
					Debug.Log("Aun hay espacio Bota");

					for(int i = 0; i < posicionesBota.Length; i++) 
					{
						if(!posicionesBota[i].GetComponent<ControlPosicion>().getOcupado())
						{
							Debug.Log("Puede Ser Ocupado");
							Instantiate(bota,posicionesBota[i].transform.position, Quaternion.identity);
							posicionesBota[i].GetComponent<ControlPosicion>().setOcupado(true);
							bota.GetComponent<ItemPosition>().setPosition(i);
							botaVariable++;
							break;
						}
						else 
						{
							Debug.Log ("NO!!! Ser Ocupado");
						}
					}
				}
			}
			if(random == 99)
			{
				//Capa
				//capaVariable = 0;
				if(this.capaVariable < this.maxCapa)
				{
					Debug.Log("Aun hay espacio");

					for(int i = 0; i < posicionesCapa.Length; i++) 
					{
						if(!posicionesCapa[i].GetComponent<ControlPosicion>().getOcupado())
						{
							Debug.Log("Puede Ser Ocupado");
							Instantiate(capa,posicionesCapa[i].transform.position, Quaternion.identity);
							posicionesCapa[i].GetComponent<ControlPosicion>().setOcupado(true);
							capa.GetComponent<ItemPosition>().setPosition(i);
							capaVariable++;
							break;
						}
						else 
						{
							Debug.Log ("NO!!! Ser Ocupado");
						}
					}
				}
			}
		}
	}

	public void disminuyeBota()
	{
		Debug.Log("Disminute bota: " + botaVariable);
		botaVariable = botaVariable - 1;
	}

	public void disminuyePollo()
	{
		Debug.Log("Disminute Pollo: "+ polloVariable);
		polloVariable = polloVariable - 1;
	}

	public void disminuyeVial()
	{
		Debug.Log("Disminute Vial " + vialVariable);
		vialVariable = vialVariable - 1;
	}

	public void disminuyeCapa()
	{
		Debug.Log("Disminute capa "+capaVariable);
		capaVariable = capaVariable - 1;
	}

	public void liberaEspacio(string tag, int pos)
	{
		Debug.Log("Revisamos; "+tag+ " "+pos);
		if(tag.Equals ("Pollo")) 
		{
			posicionesPollo[pos].GetComponent<ControlPosicion>().setOcupado(false);
		}
		else if(tag.Equals ("Bota")) 
		{
			posicionesBota[pos].GetComponent<ControlPosicion>().setOcupado(false);
		}
		else if(tag.Equals ("Vial")) 
		{
			posicionesVial[pos].GetComponent<ControlPosicion>().setOcupado(false);
		}
		else if(tag.Equals ("Capa")) 
		{
			posicionesCapa[pos].GetComponent<ControlPosicion>().setOcupado(false);
		}
	}
}
