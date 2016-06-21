using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RayScript : MonoBehaviour {

	Text m_Text;
	PlayerController m_Player;
	private int m_raysCounter = -1;
	// Use this for initialization
	void Start () {
		m_Text = GameObject.Find ("Text").GetComponent<Text> ();
		m_Player = GameObject.Find ("Player").GetComponent<PlayerController> ();
	}

	public void Update(){
		if (m_Player.m_raysCounter == m_raysCounter) {
			return;
		}
		m_raysCounter = m_Player.m_raysCounter;

		m_Text.text = "" + m_Player.m_raysCounter;
	}
}
