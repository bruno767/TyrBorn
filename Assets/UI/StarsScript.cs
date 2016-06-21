using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StarsScript : MonoBehaviour {

    public Sprite empty;
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
			sprites[i].sprite = (i < m_Player.m_starsCounter) ? normal : empty;
		}

	}

}
