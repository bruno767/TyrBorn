using UnityEngine;
using System.Collections;

public class MonsterAI : MonoBehaviour {


	[Header("Player Object")]
	public GameObject Player;


	[Header("Variables")]
	[Range(5,100)]
	public float triggerDistance;


	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (distance () < triggerDistance) {

			Vector3 targetDirection = (Player.transform.position - transform.position);
			targetDirection.y = 0;

			if (distance () < 1.2f) {
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
		}
	}

	// Calculate distance between NPC and Tim
	float distance(){

		Vector3 thispos = transform.position;
		Vector3 timpos = Player.transform.position;

		return Mathf.Sqrt (Mathf.Pow(timpos.x - thispos.x,2) + Mathf.Pow(timpos.y - thispos.y,2) + Mathf.Pow(timpos.z - thispos.z,2));
	}
}
