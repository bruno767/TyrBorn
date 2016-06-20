using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;


public class ArtificialGravity : MonoBehaviour {

	private Rigidbody m_Rb;

	GameObject planet;
	// Use this for initialization
	void Start () {
		planet = GameObject.Find ("/1Orbit/Sphere");

		m_Rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 dg = (planet.transform.position - transform.position).normalized;
		Vector3 g = dg * 10;

		transform.up = -dg;
		m_Rb.AddForce(g*m_Rb.mass);


		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		float v = CrossPlatformInputManager.GetAxis("Vertical");


		Transform m_Cam = Camera.main.transform;
		Vector3 m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;

		//Debug.DrawRay (transform.position, Vector3.ProjectOnPlane(m_Cam.forward, -dg).normalized);

//		Vector3 move = transform.forward * h + transform.right * v;


	/*	Debug.DrawRay (transform.position, move);
		if (CheckGroundStatus ()) {
			m_Rb.velocity = move*10;

			//transform.Rotate(0, m_TurnAmount * turnSpeed * Time.deltaTime, 0);

		}
		*/
	}


	bool CheckGroundStatus()
	{
		Vector3 gravity = (planet.transform. position - transform.position).normalized;


		RaycastHit hitInfo;
		#if UNITY_EDITOR
		// helper to visualise the ground check ray in the scene view
		Debug.DrawLine(transform.position + (-gravity * 0.1f), transform.position + (-gravity * 0.1f) + (gravity * 1.5f));
		#endif
		// 0.1f is a small offset to start the ray from inside the character
		// it is also good to note that the transform position in the sample assets is at the base of the character
		if (Physics.Raycast(transform.position + (-gravity * 0.1f), gravity, out hitInfo, 1.5f))
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}



//Debug.DrawLine (transform.position, transform.position + transform.forward);
//Quaternion rotation = Quaternion.LookRotation (new Vector3(0,0,-1), (-gravity).normalized);
//this.GetComponent<Transform> ().localRotation = rotation;

//Vector3 forward = Vector3.ProjectOnPlane (transform.forward, -gravity);
//transform.rotation = Quaternion.LookRotation (forward);
//transform.rotation = Quaternion.LookRotation (forward);
//;
//transform.rotation = Quaternion.LookRotation(gravity.
//transform.up = - gravity + transform.localRotation;
//Vector3 headPosition = this.transform.position + GameObject.Find ("Head").GetComponent<Transform> ().position;
//Vector3 forward = headPosition - this.transform.position;


//Vector3 forward = new Vector3 (gravity.y, gravity.x, gravity.z);
//
//rotation.y += 90;
//

//Vector3 target = Time.deltaTime*this.GetComponent<Rigidbody> ().velocity - this.transform.position;
//target.y -= 45;
//GameObject.Find ("MainCamera").GetComponent<Transform> ().LookAt (target);