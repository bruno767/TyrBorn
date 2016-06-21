using UnityEngine;
using System.Collections;

public class MonsterAI : MonoBehaviour {


	private GameObject Player;
	private bool goBack;

	[Header("Variables")]
	[Range(5,100)]
	public float triggerDistance;


	private Animator anim;
	private Vector3 initialPosition;

	// Use this for initialization
	void Start () {
		
		Player = GameObject.Find ("main_caracter");
		anim = GetComponent<Animator> ();
		triggerDistance = 30;
		initialPosition = transform.position;
		goBack = false;
	}
	
	// Update is called once per frame
	void Update () {


		if (distance (transform.position, initialPosition) > 40) {
			goBack = true;
		}

		if (goBack) {

			if (distance (transform.position, initialPosition) <= 2) {
				goBack = false;

				anim.SetBool ("sawEnemy", false);
				anim.SetBool ("walk", false);
			} else {
				anim.SetBool ("walk", true);
				anim.SetBool ("sawEnemy", false);

			}
				
			Vector3 targetDirection = (initialPosition - transform.position);
			targetDirection.y = 0;

			var rotation = Quaternion.LookRotation (targetDirection);

			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime*5); 

			transform.position += transform.forward * Time.deltaTime;
		}
		else if (!goBack && distance (transform.position, Player.transform.position) < triggerDistance) {

			if (distance (transform.position,initialPosition) > 40) {
				goBack = true;
				return;
			}

			Vector3 targetDirection = (Player.transform.position - transform.position);
			targetDirection.y = 0;

			if (distance (transform.position, Player.transform.position) < 1.2f) {
				anim.SetBool ("sawEnemy", true);
				anim.SetBool ("attackProximity", true);
			} else {
				anim.SetBool ("sawEnemy", true);
				anim.SetBool ("attackProximity", false);

				var rotation = Quaternion.LookRotation (targetDirection);

				transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime*5); 

				transform.position += transform.forward * Time.deltaTime;
			}
		} else {
			anim.SetBool ("sawEnemy", false);
			anim.SetBool ("attackProximity", false);
			anim.SetBool ("walk", false);
		}
	}

	// Calculate distance between NPC and Tim
	float distance(Vector3 currentPos, Vector3 target){

		return Mathf.Sqrt (Mathf.Pow(target.x - currentPos.x,2) + Mathf.Pow(target.y - currentPos.y,2) + Mathf.Pow(target.z - currentPos.z,2));
	}
}
