using UnityEngine;
using System.Collections;

public class InterPlanetaryTeleporter : Transporter {

	public static Color enabledColor = Color.green;
	public static Color disabledColor = Color.clear; 

	private PlayerController m_PlayerController;
	Renderer m_renderer;

	private static int m_numberOfStars = 4;

	void Start(){
		base.Start();
		m_PlayerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController>();
		m_renderer = GetComponent<Renderer>();
	}


	void Update(){
		if (m_PlayerController.m_starsCounter >= m_numberOfStars) {
			m_renderer.material.SetColor ("_EmissionColor", enabledColor);
		} else {
			m_renderer.material.SetColor ("_EmissionColor", disabledColor);
		}
	}





	void OnTriggerEnter (Collider collision) {
		if (m_PlayerController.m_starsCounter >= m_numberOfStars) {
			transport ();
			m_PlayerController.m_starsCounter = 0;
		}
	}


}
