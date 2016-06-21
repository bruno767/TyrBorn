using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[Range(0,999)]
	public int m_raysCounter;
	[Range(0,5)]
	public int m_starsCounter;
	[Range(0,8)]
	public int m_lifeCounter;


	void Start(){
		m_raysCounter = 0;
		m_starsCounter = 0;
		m_lifeCounter = 8;
	}
		
}
