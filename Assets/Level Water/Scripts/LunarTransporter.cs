using UnityEngine;
using System.Collections;

public class LunarTransporter : Transporter {

	public static Color enabledColor = Color.green;
	public static Color disabledColor = Color.clear; 
	public static Color readyColor = Color.blue; 
	public float m_maxDistance;


	private PlayerController m_PlayerController;
	Renderer m_renderer;

	private static int m_numberOfRays = 8;

	void Start(){
		base.Start();
		m_PlayerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController>();
		m_renderer = GetComponent<Renderer>();
	}


	void Update(){
		if (isReady() && m_PlayerController.m_raysCounter >= m_numberOfRays) {
			m_renderer.material.SetColor ("_EmissionColor", enabledColor);
		} else if(isReady()){
			m_renderer.material.SetColor ("_EmissionColor", readyColor);
		} else {
			m_renderer.material.SetColor ("_EmissionColor", disabledColor);
		}
	}

	public bool isReady(){
		//Debug.DrawRay (transform.position, (m_target.transform.position - transform.position).normalized * m_maxDistance);

		float distance = Vector3.Distance (transform.position, base.m_target.transform.position);
		return distance <= m_maxDistance;
	}

	void OnCollisionEnter (Collision collision) {
		if (isReady() && m_PlayerController.m_raysCounter >= m_numberOfRays) {
			transport ();
			m_PlayerController.m_raysCounter -= m_numberOfRays;
		}
	}


}
