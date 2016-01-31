using UnityEngine;
using System.Collections;

public class ControlMecanim : MonoBehaviour 
{
	public float pesoLayerTorso = 1;
	
	private Animator controlAnimator;
	private AnimatorStateInfo informacionEstado;
	
	public Transform objetivoIK;
	public float pesoIKmano;
	
	public Transform objetivoLook;
	public float pesoTotal;
	public float pesoOjos;
	public float pesoCabeza;
	public float pesoCuerpo;
	public float clampGeneral;
	
	

	// Use this for initialization
	void Start () 
	{
		controlAnimator = gameObject.GetComponent<Animator>();
		controlAnimator.SetLayerWeight(1, pesoLayerTorso);
	}	
	
	void Update () 
	{

		
		controlAnimator.SetBool("correr", Input.GetKey(KeyCode.LeftShift));
		
		controlAnimator.SetFloat("ejeVertical", Input.GetAxis("Vertical"));
		controlAnimator.SetFloat("ejeHorizontal", Input.GetAxis("Horizontal"));
		
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			controlAnimator.SetBool("alzarMano", true);
		}
		if(Input.GetKeyUp(KeyCode.Alpha1))
		{
			controlAnimator.SetBool("alzarMano", false);
		}
		
		gameObject.GetComponent<CapsuleCollider>().height = controlAnimator.GetFloat("colliderAltura");
		gameObject.GetComponent<CapsuleCollider>().center = new Vector3(0, controlAnimator.GetFloat("colliderPosicionY"),0);		
	}
	
	void OnAnimatorIK()
	{
		controlAnimator.SetIKPosition(AvatarIKGoal.LeftHand, objetivoIK.position);		
		controlAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, pesoIKmano);
		
		controlAnimator.SetIKRotation(AvatarIKGoal.LeftHand, objetivoIK.rotation);
		controlAnimator.SetIKRotationWeight(AvatarIKGoal.LeftHand, pesoIKmano);
		
		controlAnimator.SetLookAtPosition(objetivoLook.position);
		controlAnimator.SetLookAtWeight(pesoTotal, pesoCuerpo, pesoCabeza, pesoOjos,clampGeneral);
						
	}
	
}
