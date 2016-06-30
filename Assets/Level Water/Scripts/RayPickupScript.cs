using UnityEngine;
using System.Collections;

public class RayPickupScript : MonoBehaviour {
	private PlayerController m_player;

	private BoxCollider m_BoxCollider;
	private MeshRenderer m_MeshRenderer;
	private bool isOn;
	private float catchTime;


	[Range(0,100)]
	public float respawnDuration = 1f;


	// Use this for initialization
	void Start () {
		m_player = GameObject.Find ("Player").GetComponent<PlayerController> ();
		m_BoxCollider = GetComponent<BoxCollider> ();
		m_MeshRenderer = GetComponent<MeshRenderer> ();
		setOn (true);
	}


	void OnTriggerEnter(Collider other) {
		if (isOn && other.gameObject.transform.parent.gameObject.tag == "Player") {
			setOn (false);
			catchTime = Time.fixedTime;

			m_player.m_raysCounter += 1;
			AudioSource source = GetComponentInParent<AudioSource>();
			if (source != null)
			{
				GetComponentInParent<AudioSource>().Stop();
				GetComponentInParent<AudioSource>().Play();
			}
		}
	}

	void FixedUpdate(){
		if (!isOn && Time.fixedTime >= catchTime + respawnDuration) {
			setOn (true);
		}
	}

	void setOn(bool on){
		m_MeshRenderer.enabled = on;
		m_BoxCollider.enabled = on;
		isOn = on;
	}
}
