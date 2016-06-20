using UnityEngine;
using System.Collections;

public class ArtificialGravity : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Physics.gravity = new Vector3(0, -1.0F, 0);

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		Debug.Log (this.transform.forward);

		Vector3 gravity = 10 * (new Vector3 (0, 0, 0) - this.GetComponent<Transform> ().position).normalized;
		Debug.DrawLine (new Vector3 (0, 0, 0), -gravity);
		//Quaternion rotation = Quaternion.LookRotation (new Vector3(0,0,-1), (-gravity).normalized);
		//this.GetComponent<Transform> ().localRotation = rotation;
		transform.up = -gravity;

		this.GetComponent<Rigidbody>().AddForce(gravity);

		//Vector3 headPosition = this.transform.position + GameObject.Find ("Head").GetComponent<Transform> ().position;
		//Vector3 forward = headPosition - this.transform.position;


		//Vector3 forward = new Vector3 (gravity.y, gravity.x, gravity.z);
		//
		//rotation.y += 90;
		//

		//Vector3 target = Time.deltaTime*this.GetComponent<Rigidbody> ().velocity - this.transform.position;
		//target.y -= 45;
		//GameObject.Find ("MainCamera").GetComponent<Transform> ().LookAt (target);
	}
}
