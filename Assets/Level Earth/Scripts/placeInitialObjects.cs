using UnityEngine;
using System.Collections;

public class placeInitialObjects : MonoBehaviour {

	public GameObject stone1;
	public GameObject stone2;
	public GameObject stone3;
	public GameObject stone4;

	public GameObject Animal1;


	// Use this for initialization
	void Start () {
		spawnStones ();
		spawnAnimals ();
	}

	void spawnStones () {

		// Map size
		int x = 500;
		int z = 500;

		for (int i = 0; i < 1000; i += 1) {
			Vector3 vec = new Vector3 (Random.Range(5,x-5), Random.Range(-1f,0f), Random.Range(5,z-5));

			int nextStone = Random.Range (0, 5);

			if (nextStone == 0) {
				Instantiate (stone1, vec, validRotationAngle (false));
			} else if (nextStone == 1) {
				Instantiate (stone2, vec, validRotationAngle (true));
			} else if (nextStone == 2) {
				Instantiate (stone3, vec, validRotationAngle (true));
			} else {
				Instantiate(stone4, vec, validRotationAngle (true));
			}
		}
	}

	void spawnAnimals () {

		// Map size
		int x = 500;
		int z = 500;

		for (int i = 0; i < 20; i += 1) {
			Vector3 vec = new Vector3 (Random.Range(5,x-5), 0, Random.Range(5,z-5));

			int nextAnimal = 0;//Random.Range (0, 5);

			if (nextAnimal == 0) {
				Instantiate (Animal1, vec, validRotationAngle (true));
			} /*else if (nextAnimal == 1) {
				Instantiate (stone2, vec, validRotationAngle (true));
			} else if (nextAnimal == 2) {
				Instantiate (stone3, vec, validRotationAngle (true));
			} else {
				Instantiate(stone4, vec, validRotationAngle (true));
			}*/
		}
	}

	//Function that returns a valid Vector3 rotation
	Quaternion validRotationAngle(bool val){
		if (!val)
			return Quaternion.Euler (0, 0, (float)Random.Range (0, 360));
		else return Quaternion.Euler ((float)Random.Range(0,360),0,(float)Random.Range(0,360));
	}
}
