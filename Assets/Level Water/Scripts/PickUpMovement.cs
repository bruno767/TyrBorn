using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PickUpMovement : MonoBehaviour {

	[Range(0,100)]
	public float angularVelocity = 30f;
	[Range(0,3)]
	public float verticalVelocity = 1f;
	[Range(0,10)]
	public float verticalVariance = 1f;
	private float time = 0f;

	[Range(0,100)]
	public float respawnDuration = 1f;

	private float catchTime;

	private Vector3 mStartPosition;

	private StarsScript m_starts;
	private RayScript m_rays;
	private BoxCollider m_BoxCollider;
	private MeshRenderer m_MeshRenderer;
	private bool isOn;
	public Transform m_AssociatedPlanet;
	private PlayerController m_player;
	void Start(){
		m_player = GameObject.Find ("Player").GetComponent<PlayerController> ();
		mStartPosition = transform.position;
		m_starts = GameObject.Find("Stars").GetComponent<StarsScript>();
		m_rays = GameObject.Find("Rays").GetComponent<RayScript>();
		m_BoxCollider = GetComponent<BoxCollider> ();
		m_MeshRenderer = GetComponent<MeshRenderer> ();
		setOn (true);

	}

	void FixedUpdate(){
		if (!isOn && Time.fixedTime >= catchTime + respawnDuration) {
			setOn (true);
		}
	}

	// Update is called once per frame
	void Update () {
		transform.RotateAround (transform.position, transform.up, angularVelocity * Time.deltaTime);
		time += Time.deltaTime * verticalVelocity;
		transform.position = mStartPosition + transform.up * Mathf.Cos (time) * verticalVariance;
	}

	void OnTriggerEnter(Collider other) {
		

		//Debug.Log (other.gameObject);
		if (other.gameObject.transform.parent.gameObject.tag == "Player") {
			setOn (false);
			catchTime = Time.fixedTime;

			++m_player.m_raysCounter;
			AudioSource source = GetComponentInParent<AudioSource>();
			if (source != null)
			{
				GetComponentInParent<AudioSource>().Stop();
				GetComponentInParent<AudioSource>().Play();
			}
		}
	}

	void setOn(bool on){
		m_MeshRenderer.enabled = on;
		m_BoxCollider.enabled = on;
		isOn = on;
	}
}
