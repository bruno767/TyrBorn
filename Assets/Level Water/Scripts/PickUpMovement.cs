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
	private Vector3 mLastDelta;

	void Start(){
		mLastDelta = new Vector3 (0f, 0f, 0f);
	}

	// Update is called once per frame
	void Update () {
		transform.RotateAround (transform.position, transform.up, angularVelocity * Time.deltaTime);
		time += Time.deltaTime * verticalVelocity;
		Vector3 delta = transform.up * Mathf.Cos (time) * verticalVariance;
		transform.position += mLastDelta - delta;
		mLastDelta = delta;
	}

}