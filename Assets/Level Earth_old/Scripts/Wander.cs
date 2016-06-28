using UnityEngine;
using System.Collections;


public class Wander : MonoBehaviour
{
	public float maxHeadingChange = 30;
	public float directionChangeInterval = 5;

	private int animationRightNow; // 0 -> Idle , 1 -> Walk , 2 -> Run
	private Animator animal;

	CharacterController controller;
	float heading;
	Vector3 targetRotation;

	void Awake ()
	{
		animal = GetComponent<Animator> ();
		StartCoroutine(NewHeading());
	}

	void Update ()
	{
		transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);
		var forward = transform.TransformDirection(Vector3.forward);

		if (animationRightNow != 0)
			transform.position += forward * Time.deltaTime * directionChangeInterval;
	}
		
	IEnumerator NewHeading ()
	{
		while (true) {
			NewHeadingRoutine();
			yield return new WaitForSeconds(directionChangeInterval);
		}
	}
		
	void NewHeadingRoutine ()
	{
		var floor = Mathf.Clamp(heading - maxHeadingChange, 0, 360);
		var ceil  = Mathf.Clamp(heading + maxHeadingChange, 0, 360);
		heading = Random.Range(floor, ceil);
		targetRotation = new Vector3(0, heading, 0);

		// Change animation
		animationRightNow = Random.Range(0,3);
		animal.SetInteger("Type",animationRightNow);
	}
}