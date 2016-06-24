using UnityEngine;
using System.Collections;

public class StarBehaviour : MonoBehaviour {
	private PlayerController m_player;

	void Start(){
		m_player = GameObject.Find ("Player").GetComponent<PlayerController> ();
	}

	void OnTriggerEnter(Collider other) {
		//Debug.Log (other.gameObject);
		if (other.gameObject.transform.parent.gameObject.tag == "Player") {
			++m_player.m_starsCounter;
			AudioSource source = GetComponentInParent<AudioSource>();
            source.volume = 0.1f;
			if (source != null)
			{
				GetComponentInParent<AudioSource>().Stop();
				GetComponentInParent<AudioSource>().Play();
			}
			Destroy (this.gameObject);
		}
	}
}
