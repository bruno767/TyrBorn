using UnityEngine;
using System.Collections;

public class Transporter : MonoBehaviour {

	private SimpleController m_Player; 
	public GameObject m_target;

	// Use this for initialization
	public void Start () {
		m_Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<SimpleController>();

	}

	public void transport(){
		//if (isEnabled()) {
			//GameObject.Find("Stars").GetComponent<StarsScript>().ResetStars();
			m_Player.SetAssociatedPlanet (m_target, true);
		//}
	}

}


