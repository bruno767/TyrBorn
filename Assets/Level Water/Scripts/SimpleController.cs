using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class SimpleController : MovementController {
	private GameObject m_CharacterModel;
	private float fixedVelocity;
	private Animator m_anim;
    public GameObject m_footstepsSoundSource;

    // Use this for initialization
    void Start () {
		base.Start ();
		m_CharacterModel = GameObject.Find ("main_caracter");
		SetAssociatedPlanet(m_intialAssociatedPlanet, false);
		m_anim = GameObject.Find("main_caracter").GetComponent<Animator>();
	}


	public override void animate(float forwardAmount, float turnAmount){

		if (forwardAmount > 0) {
			m_anim.SetBool ("isRunning", true);
			if(isGrounded())
				m_footstepsSoundSource.GetComponent<FootstepsSoundScript>().StartWalking();
			else
				m_footstepsSoundSource.GetComponent<FootstepsSoundScript>().StopWalking();
		} else {
			m_anim.SetBool ("isRunning", false);
			m_footstepsSoundSource.GetComponent<FootstepsSoundScript>().StopWalking();
		}
	}




	// Update is called once per frame
	void FixedUpdate () {
		
		float h = CrossPlatformInputManager.GetAxis ("Horizontal");
		float v = CrossPlatformInputManager.GetAxis ("Vertical");
		bool jump = Input.GetKeyDown ("space");

		if(jump) Jump ();
		Move (v,h);




		/* 
		m_CharacterModel.transform.rotation = Quaternion.LookRotation (myForward, N);

		if (forwardAmount > 0.5f && (m_isGrounded && !jump)) {
			m_CharacterModel.transform.RotateAround (m_CharacterModel.transform.position, m_CharacterModel.transform.right, 30);
		}
		*/
		//if(h != 0 || v != 0)
		//	transform.rotation = Quaternion.LookRotation(move, N);

	}





<<<<<<< HEAD
=======
		RaycastHit hitInfo;
		#if UNITY_EDITOR
		// helper to visualise the ground check ray in the scene view
		Debug.DrawLine(transform.position + (N * 0.1f), transform.position + (N * 0.1f) + (-N * 0.5f), Color.red);
		#endif
		// 0.1f is a small offset to start the ray from inside the character
		// it is also good to note that the transform position in the sample assets is at the base of the character
		if (Physics.Raycast(transform.position + (N * 0.1f), -N, out hitInfo, 0.5f))
		{
			//m_GroundNormal = hitInfo.normal;
			m_isGrounded = true;
			//m_Animator.applyRootMotion = true;
		}
		else
		{
			m_isGrounded = false;
			//m_GroundNormal = -gravity;
			//m_Animator.applyRootMotion = false;
		}
>>>>>>> 9c034a5e673b10c83f5ef254d351139ac912e3fe

}
