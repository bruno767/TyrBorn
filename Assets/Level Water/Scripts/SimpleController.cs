using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class SimpleController : MonoBehaviour {
	private Rigidbody m_Rb;
	private GameObject m_AssociatedPlanet;
	private Transform m_Cam;
	private Vector3 N;
	private bool m_isGrounded;
	private GameObject m_CharacterModel;
	private float fixedVelocity;
	private bool m_ShootUp;
	private Vector3 m_AssociatedPlanetPosition;
	private static Vector3 NullVector3 = new Vector3 (-9999, 9999, 9999);
	public float runMultiplier, gravityMultiplier, turnMultiplier;
	private Animator m_anim;

	// Use this for initialization
	void Start () {
		m_Rb = GetComponent<Rigidbody> ();
		m_Cam = Camera.main.transform;
		m_CharacterModel = GameObject.Find ("main_caracter");
		SetAssociatedPlanet(GameObject.Find ("/1Orbit/Earth"), false);
		m_anim = GameObject.Find("main_caracter").GetComponent<Animator>();
	}


	public void SetAssociatedPlanet(GameObject planet, bool shootUp){
		m_AssociatedPlanetPosition = NullVector3;
		m_AssociatedPlanet = planet;
		m_ShootUp = shootUp;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (m_AssociatedPlanetPosition != NullVector3) {
			transform.position += m_AssociatedPlanet.transform.position - m_AssociatedPlanetPosition; 
		}

		if (m_AssociatedPlanet != null) {
			m_AssociatedPlanetPosition = m_AssociatedPlanet.transform.position;

			N = (transform.position - m_AssociatedPlanet.transform.position).normalized;
		} else {
			m_AssociatedPlanetPosition = NullVector3;
			N = new Vector3 (0, 1, 0);
		}

		if(m_ShootUp){
			m_Rb.velocity  = 10*-N;
			transform.forward = -N;
			return;
		}

		Vector3 Fg = -N * 10 * m_Rb.mass * gravityMultiplier; 

		Vector3 myForward = Vector3.ProjectOnPlane (transform.forward, N);
		Vector3 myRight = Vector3.Cross (myForward, -N); 
		Vector3.ProjectOnPlane (transform.forward, N);

		transform.rotation = Quaternion.LookRotation (myForward, N);
		m_Rb.AddForce (Fg);
		//Debug.DrawRay (transform.position, Fg.normalized, Color.red);

		float h = CrossPlatformInputManager.GetAxis ("Horizontal");
		float v = CrossPlatformInputManager.GetAxis ("Vertical");
		bool jump = Input.GetKeyDown ("space");


		Vector3 camForward = Vector3.ProjectOnPlane (m_Cam.forward, N).normalized;
		Vector3 camRight = Vector3.Cross (camForward, -N).normalized;

		Vector3 move = v * myForward + h * myRight;

		float forwardAmount = Vector3.Dot (move, myForward); 
		float hProj = Vector3.Dot (move, myRight);
		float turnAmount = amount (Vector3.Angle (myForward, move), hProj, forwardAmount);

		if (forwardAmount > 0) {
			m_anim.SetBool ("isRunning", true);
		} else {
			m_anim.SetBool ("isRunning", false);
		}

		transform.position += myForward * forwardAmount * runMultiplier;


		float rotationAngle = turnAmount * Time.deltaTime * turnMultiplier; 

		transform.RotateAround (this.transform.position, N, rotationAngle);

		CheckGroundStatus ();



		if (m_isGrounded && jump) {
			m_Rb.velocity = 10 * N;
		}


		m_CharacterModel.transform.rotation = Quaternion.LookRotation (myForward, N);

		if (forwardAmount > 0.5f && (m_isGrounded && !jump)) {
			m_CharacterModel.transform.RotateAround (m_CharacterModel.transform.position, m_CharacterModel.transform.right, 30);
		}

		//if(h != 0 || v != 0)
		//	transform.rotation = Quaternion.LookRotation(move, N);

	}

	private float amount(float angle, float x, float y){

		if (y < 0 && x > 0) { // 4Q
			return angle;
		} else if (y < 0 && x < 0) { // 3Q
			return angle - 180;
		} else if (x < 0) { // 2Q
			return -angle;
		} else if (x > 0) { // 1Q
			return angle;
		} else if (x == 0 && y < 0) {
			return 0;
		} else {
			return 0;
		}
		return 0;
	}



	void CheckGroundStatus()
	{

		RaycastHit hitInfo;
		#if UNITY_EDITOR
		// helper to visualise the ground check ray in the scene view
		Debug.DrawLine(transform.position + (N * 0.1f), transform.position + (N * 0.1f) + (-N * 0.5f));
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

	}
}
