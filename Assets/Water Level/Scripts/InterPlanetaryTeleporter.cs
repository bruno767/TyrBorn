using UnityEngine;
using System.Collections;

public class InterPlanetaryTeleporter : MonoBehaviour {

	public static Color enabledColor = Color.green;
	public static Color disabledColor = Color.clear; 

	private SimpleController m_Player; 
	public GameObject m_target;
	public float m_maxDistance;
	Renderer m_renderer;

	void Start(){
		m_Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<SimpleController>();
		m_renderer = GetComponent<Renderer>();
	}


	void Update(){
		m_renderer.material.SetColor("_EmissionColor", isEnabled() ? enabledColor : disabledColor);
	}



	void OnTriggerEnter (Collider collision) {
		if (isEnabled()) {
            GameObject.Find("Stars").GetComponent<StarsScript>().ResetStars();
            m_Player.SetAssociatedPlanet (m_target, true);
		}
	}

	bool isEnabled(){
		//Debug.DrawRay (transform.position, (m_target.transform.position - transform.position).normalized * m_maxDistance);

		float distance = Vector3.Distance (transform.position, m_target.transform.position);
		return distance <= m_maxDistance;
	}


}
