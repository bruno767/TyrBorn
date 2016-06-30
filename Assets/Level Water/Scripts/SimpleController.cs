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

}
