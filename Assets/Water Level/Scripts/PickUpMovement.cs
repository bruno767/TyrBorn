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

	[Range(0,1000)]
	public float respawnDuration = 1f;

	private float catchTime;

	private Vector3 mStartPosition;

    GameObject ui;

	void Start(){
		mStartPosition = transform.position;
        ui = GameObject.Find("Stars");
    }
	/*
	void FixedUpdate(){
		gameObject.SetActive (false);
		Debug.Log (gameObject.activeSelf);
		if (!gameObject.activeSelf && Time.fixedTime >= catchTime + respawnDuration) {
			gameObject.SetActive(true);
		}
	}*/

	// Update is called once per frame
	void Update () {
		transform.RotateAround (transform.position, transform.up, angularVelocity * Time.deltaTime);
		time += Time.deltaTime * verticalVelocity;
		transform.position = mStartPosition + transform.up * Mathf.Cos (time) * verticalVariance;
	}

	void OnTriggerEnter(Collider other) {
        ui.GetComponent<StarsScript>().IncreaseStars();
        AudioSource source = GetComponentInParent<AudioSource>();
        if (source != null)
        {
            GetComponentInParent<AudioSource>().Play();
        }

        //Debug.Log (other.gameObject);
        if (other.gameObject.transform.parent.gameObject.tag == "Player") {
			//Destroy(this.gameObject);
			StartCoroutine(LateCall());
		}
	}

	IEnumerator LateCall()
	{
		gameObject.SetActive(false);
		Debug.Log ("her");
		yield return new WaitForSeconds(1f);
		Debug.Log ("her2");

		gameObject.SetActive(true);
	}
}
