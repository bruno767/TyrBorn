using UnityEngine;
using System.Collections;

public class placeInitialObjects : MonoBehaviour {

	public GameObject stone1;
	public GameObject stone2;
	public GameObject stone3;
	public GameObject stone4;

	public GameObject Animal1;

	public GameObject Monster;

	public GameObject health;

	public GameObject soul;

	// Use this for initialization
	void Start () {
		spawnStones ();
		spawnAnimals ();
		spawnMonster ();
		spawnHealth ();
		spawnSouls ();
	}

	void spawnStones () {

		// Map size
		int x = 500;
		int z = 500;

		for (int i = 0; i < 1000; i += 1) {
			Vector3 vec = new Vector3 (Random.Range(5,x-5), Random.Range(-1f,0f), Random.Range(5,z-5));

			int nextStone = Random.Range (0, 5);
			GameObject _t;

			if (nextStone == 0) {
				_t = (GameObject) Instantiate (stone1, vec, validRotationAngle (false));
			} else if (nextStone == 1) {
				_t = (GameObject) Instantiate (stone2, vec, validRotationAngle (true));
			} else if (nextStone == 2) {
				_t = (GameObject) Instantiate (stone3, vec, validRotationAngle (true));
			} else {
				_t = (GameObject) Instantiate(stone4, vec, validRotationAngle (true));
			}

			_t.transform.parent = GameObject.Find ("stones").transform;
		}
	}

	void spawnAnimals () {

		// Map size
		int x = 500;
		int z = 500;

		GameObject _t;

		for (int i = 0; i < 20; i += 1) {
			Vector3 vec = new Vector3 (Random.Range(5,x-5), 0, Random.Range(5,z-5));

			int nextAnimal = 0;//Random.Range (0, 5);

			//if (nextAnimal == 0) {
				_t = (GameObject) Instantiate (Animal1, vec, validRotationAngle (true));
			/*} else if (nextAnimal == 1) {
				Instantiate (stone2, vec, validRotationAngle (true));
			} else if (nextAnimal == 2) {
				Instantiate (stone3, vec, validRotationAngle (true));
			} else {
				Instantiate(stone4, vec, validRotationAngle (true));
			}*/
			_t.transform.parent = GameObject.Find ("animals").transform;
		}
	}


	void spawnMonster(){
		// Map size
		int x = 500;
		int z = 500;

		GameObject _t;

		for (int i = 0; i < 250; i += 1) {
			Vector3 vec = new Vector3 (Random.Range(5,x-5), 0.1f, Random.Range(5,z-5));

			_t = (GameObject) Instantiate (Monster, vec, validRotationAngle (false));
			_t.transform.parent = GameObject.Find ("monsters").transform;
		}

	}

	void spawnHealth(){
		// Map size
		int x = 500;
		int z = 500;

		GameObject _t;

		for (int i = 0; i < 50; i += 1) {
			Vector3 vec = new Vector3 (Random.Range(5,x-5), 1f, Random.Range(5,z-5));

			_t = (GameObject) Instantiate (health, vec, validRotationAngle (false));
			_t.transform.parent = GameObject.Find ("healths").transform;
		}
	}

	void spawnSouls(){
		// Map size
		int x = 500;
		int z = 500;

		GameObject _t;

		for (int i = 0; i < 7; i += 1) {
			Vector3 vec = new Vector3 (Random.Range(5,x-5), 1, Random.Range(5,z-5));

			_t = (GameObject) Instantiate (soul, vec, validRotationAngle (false));
			_t.transform.parent = GameObject.Find ("souls").transform;
		}
	}

	//Function that returns a valid Vector3 rotation
	Quaternion validRotationAngle(bool val){
		if (!val)
			return Quaternion.Euler (0, 0, (float)Random.Range (0, 360));
		else return Quaternion.Euler ((float)Random.Range(0,360),0,(float)Random.Range(0,360));
	}
}
