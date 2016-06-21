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
	private Vector3 mStartPosition;

	void Start(){
		mStartPosition = transform.position;
	}

	// Update is called once per frame
	void Update () {
		transform.RotateAround (transform.position, transform.up, angularVelocity * Time.deltaTime);
		time += Time.deltaTime * verticalVelocity;
		transform.position = mStartPosition + transform.up * Mathf.Cos (time) * verticalVariance;
	}

}
