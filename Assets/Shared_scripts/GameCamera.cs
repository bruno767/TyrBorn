using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {

	private GameObject m_Player;
	private Camera m_Camera;

	public float m_VerticalDistanceToPlayer;
	public float m_HorizontalDistanceToPlayer;
	public float m_movingStep;
	private float m_VerticalMove;

	// Use this for initialization
	void Start () {
		m_Player = GameObject.Find ("Player");
		m_Camera = GetComponent<Camera> ();

	}

	// Update is called once per frame
	void FixedUpdate () {

		float axisY = 0;//Input.GetAxis ("Mouse Y");
		float axisX =  0;//Input.GetAxis ("Mouse X");

		float baseDistance = Mathf.Sqrt(Mathf.Pow (m_VerticalDistanceToPlayer,2) + Mathf.Pow (m_HorizontalDistanceToPlayer,2));

		// camera at
		Vector3 cameraPosition = m_Player.transform.position;
		cameraPosition -= m_HorizontalDistanceToPlayer* m_Player.transform.forward;
		cameraPosition += (-2*axisY + m_VerticalDistanceToPlayer)*m_Player.transform.up;
		cameraPosition += -2 * axisX * m_Player.transform.right;
		float distance = Vector3.Distance (transform.position, cameraPosition);

		float step =  Mathf.Log (1 + m_movingStep*distance);

		transform.position = Vector3.MoveTowards (transform.position, cameraPosition, step < 0 ? 0 : step);

		Debug.DrawLine (transform.position, cameraPosition);


		// look to
		Vector3 lookRay = m_Player.transform.position - transform.position + m_Player.transform.up;
		Quaternion cameraRotation =  Quaternion.LookRotation (lookRay, m_Player.transform.up);
		transform.rotation = cameraRotation;
	}
		
}
