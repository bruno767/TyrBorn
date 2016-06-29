using UnityEngine;
using System.Collections;

public class AssociatedPlanetSetter : MonoBehaviour {

	private SimpleController m_Player;
	void Start(){
		m_Player = GameObject.Find ("Player").GetComponent<SimpleController>();
	}

	// Use this for initialization
	void OnTriggerEnter () {
		m_Player.SetAssociatedPlanet (transform.parent.gameObject, false);
	}
}
