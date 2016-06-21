using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HeartsScript : MonoBehaviour {

	public Sprite empty;
	public Sprite half;
	public Sprite normal;

	Image[] sprites;
	PlayerController m_Player;

	void Start()
	{
		sprites = GetComponentsInChildren<Image>();
		m_Player = GameObject.Find ("Player").GetComponent<PlayerController> ();

	}

	public void Update(){
		for(int i = 0; i < sprites.Length; i++)
		{
			if (2*i < m_Player.m_lifeCounter && 2*i + 1 < m_Player.m_lifeCounter) {
				sprites [i].sprite = normal;
			} else if (2*i < m_Player.m_lifeCounter) {
				sprites [i].sprite = half;
			} else {
				sprites [i].sprite = empty;
			}			
		}

	}
}
