using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RayScript : MonoBehaviour {

	Text m_Text;
	PlayerController m_Player;
	// Use this for initialization
	void Start () {
		m_Text = GameObject.Find ("Text").GetComponent<Text> ();
		m_Player = GameObject.Find ("Player").GetComponent<PlayerController> ();
	}

	public void Update(){
		m_Text.text = "" + m_Player.m_raysCounter;
	}
}
