using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {

	private GameObject m_Player;
	private Camera m_Camera;

	public float m_VerticalDistanceToPlayer;
	public float m_HorizontalDistanceToPlayer;
	private float m_VerticalMove;

	// Use this for initialization
	void Start () {
		m_Player = GameObject.Find ("Player");
		m_Camera = GetComponent<Camera> ();

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	// Update is called once per frame
	void Update () {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		float axisY = Input.GetAxis ("Mouse Y");
		float axisX =   Input.GetAxis ("Mouse X");


		// camera at
		Vector3 cameraPosition = m_Player.transform.position;
		cameraPosition -= m_HorizontalDistanceToPlayer* m_Player.transform.forward;
		cameraPosition += (-2*axisY + m_VerticalDistanceToPlayer)*m_Player.transform.up;
		cameraPosition += -2 * axisX * m_Player.transform.right;
		transform.position = cameraPosition;

		// look to
		Vector3 lookRay = m_Player.transform.position - transform.position + m_Player.transform.up;
		Quaternion cameraRotation =  Quaternion.LookRotation (lookRay, m_Player.transform.up);
		transform.rotation = cameraRotation;
	}

	void FixedUpdate(){
		


	}
}
