using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ControlMenu : MonoBehaviour 
{
	public GameObject edificioPrefab;
	public Transform spawnPointEdificio;
	
	private GameObject ultimoEdificioSeleccionado;
	private GameObject ultimaUnidadSeleccionada;
	
	private GameObject ultimoEdificioCreado;
	private RaycastHit infoRayo;
	private bool creandoEdificio;
	private bool hayEdificioSeleccionado;
	private bool hayUnidadSeleccionada;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(creandoEdificio)
		{
			if(EmitirRayo())
			{
				ultimoEdificioCreado.transform.position = infoRayo.point;
				if(infoRayo.collider.gameObject.CompareTag("Escenario")) //Si se puede poner
				{
					ultimoEdificioCreado.GetComponent<ControlEdificio>().SetColocable(true);
					if(Input.GetMouseButtonDown(0))//Lo quiere poner?
					{			
						ultimoEdificioCreado.GetComponent<ControlEdificio>().ColocarEdificio();
						ultimoEdificioCreado.GetComponent<ControlEdificio>().miMenu = gameObject.GetComponent<ControlMenu>();
						creandoEdificio = false;
						//Ya se coloco el edificio;						
					}
				}
				else//No se puede poner
				{
					ultimoEdificioCreado.GetComponent<ControlEdificio>().SetColocable(false);
				}
			}
			else
			{
				ultimoEdificioCreado.transform.position = spawnPointEdificio.position;
			}			
		}	
		if(hayUnidadSeleccionada)
		{
			if(Input.GetMouseButtonDown(1))
			if(EmitirRayo())
			{
				if(infoRayo.collider.gameObject.CompareTag("Escenario"))
				{
					ultimaUnidadSeleccionada.SendMessage("SetDestination", infoRayo.point,SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}
	
	void OnGUI()
	{
		if(hayEdificioSeleccionado)
		{
			Vector3 edificioEnPantalla = Camera.mainCamera.WorldToScreenPoint(ultimoEdificioSeleccionado.transform.position);
			GUI.Box(new Rect(edificioEnPantalla.x, Screen.height - edificioEnPantalla.y, 200,30),"Edificio " + ultimoEdificioSeleccionado.GetInstanceID());
			
			if(GUI.Button(new Rect(Screen.width * 0.2f,Screen.height * 0.85f, Screen.width *0.2f, Screen.height * 0.05f ), "Unidad" ))
			{
				ultimoEdificioSeleccionado.SendMessage("CrearUnidad",SendMessageOptions.DontRequireReceiver);
			}
			
			if(GUI.Button(new Rect(Screen.width * 0.1f,Screen.height * 0.8f, Screen.width *0.1f, Screen.height * 0.1f ), "(X)" ))
			{				
				ultimoEdificioSeleccionado.SendMessage("SetSelected",false,SendMessageOptions.DontRequireReceiver);					
				hayEdificioSeleccionado = false;
			}			
		}
		else if( hayUnidadSeleccionada)
		{
			Vector3 unidadEnPantalla = Camera.mainCamera.WorldToScreenPoint(ultimaUnidadSeleccionada.transform.position);
			GUI.Box(new Rect(unidadEnPantalla.x, Screen.height - unidadEnPantalla.y, 200,30),"Unidad " + ultimaUnidadSeleccionada.GetInstanceID());

			if(GUI.Button(new Rect(Screen.width * 0.1f,Screen.height * 0.8f, Screen.width *0.1f, Screen.height * 0.1f ), "(X)" ))
			{				
				ultimaUnidadSeleccionada.SendMessage("SetSelected",false,SendMessageOptions.DontRequireReceiver);					
				hayUnidadSeleccionada = false;
			}				
		}
		else if(creandoEdificio==false)
		{
			//Boton Crear Edifico
			if(GUI.Button(new Rect(Screen.width * 0.1f,Screen.height * 0.8f, Screen.width *0.3f, Screen.height * 0.1f ), "Edificio" ))
			{				
				if(ultimoEdificioSeleccionado)
				{
					ultimoEdificioSeleccionado.SendMessage("SetSelected",false,SendMessageOptions.DontRequireReceiver);					
					hayEdificioSeleccionado = false;
				}
				ultimoEdificioCreado = (GameObject)Instantiate(edificioPrefab, spawnPointEdificio.position, Quaternion.identity);				
				ultimoEdificioSeleccionado = ultimoEdificioCreado;
				creandoEdificio=true;
			}
		}
		else//Modo de Crear Edificio
		{
			if(GUI.Button(new Rect(Screen.width * 0.1f,Screen.height * 0.8f, Screen.width *0.1f, Screen.height * 0.1f ), "(X)" ))
			{
				//Modo de Crear Edificio
				Destroy(ultimoEdificioCreado);
				creandoEdificio=false;
			}
		}		
	}
	
	private bool EmitirRayo()
	{
		bool hayHit = false;		
		hayHit = Physics.Raycast((Camera.mainCamera.ScreenPointToRay( new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0))), out infoRayo);
		return hayHit;
	}
	
	
	public void SetSeleccionEdificio(bool estaSeleccionado, GameObject edificioSeleccionado)
	{
		if(creandoEdificio==false)
		{
			ultimoEdificioSeleccionado.SendMessage("SetSelected",false,SendMessageOptions.DontRequireReceiver);
			ultimoEdificioSeleccionado = edificioSeleccionado;
			
			if(ultimaUnidadSeleccionada)
			ultimaUnidadSeleccionada.SendMessage("SetSelected",false,SendMessageOptions.DontRequireReceiver);
			hayUnidadSeleccionada=false;
		
			ultimoEdificioSeleccionado.SendMessage("SetSelected",estaSeleccionado, SendMessageOptions.DontRequireReceiver);
		
			hayEdificioSeleccionado=estaSeleccionado;		
		}
	}
	
	public void SetSeleccionUnidad(bool estaSeleccionado, GameObject unidadSeleccionada)
	{
		if(creandoEdificio==false)
		{
			if(ultimaUnidadSeleccionada)
			ultimaUnidadSeleccionada.SendMessage("SetSelected",false,SendMessageOptions.DontRequireReceiver);
			ultimaUnidadSeleccionada = unidadSeleccionada;
			
			
			ultimoEdificioSeleccionado.SendMessage("SetSelected",false,SendMessageOptions.DontRequireReceiver);
			hayEdificioSeleccionado=false;
			
			ultimaUnidadSeleccionada.SendMessage("SetSelected",estaSeleccionado,SendMessageOptions.DontRequireReceiver);
			hayUnidadSeleccionada=estaSeleccionado;			
		}		
	}
}
