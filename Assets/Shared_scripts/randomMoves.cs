using UnityEngine;
using System.Collections;

public class randomMoves : MonoBehaviour {

	[Header("Vertical Movement",order=1)]
	[Tooltip("Check this box if you want the stone to move vertically")]
	public bool vertical;

	[Header("Parameters",order=1)]
	[Tooltip("Tweak parameters")]
	[Range(0,10)]
	public float velocity = 1f;
	[Range(0,30)]
	public float maxDistance = 1f;
	public int minimum_star = 0;
	public int minimum_rays = 0;


	private Vector3 initialPos;
	private bool onSpot;

	// Use this for initialization
	void Start () {
		initialPos = this.transform.position;
		onSpot = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (GameObject.Find ("Player").GetComponent<PlayerController> ().m_starsCounter >= minimum_star &&
		    GameObject.Find ("Player").GetComponent<PlayerController> ().m_raysCounter >= minimum_rays) {

			if (distance (initialPos, transform.position) < 1) {
				onSpot = true;
			}

			if (vertical) {
				this.transform.position += new Vector3 (0, velocity * Time.deltaTime, 0);
			} else {
				this.transform.position += new Vector3 (0, 0, velocity * Time.deltaTime);
			}

			if (onSpot && distance (transform.position, initialPos) > maxDistance) {
				velocity *= -1;
				onSpot = false;
			}
		}
	
	}


	float distance(Vector3 cur, Vector3 dest){


		return Mathf.Sqrt (Mathf.Pow(dest.x - cur.x,2) + Mathf.Pow(dest.y - cur.y,2) + Mathf.Pow(dest.z - cur.z,2));
	}
}
