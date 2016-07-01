using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadNewSceneEnd : MonoBehaviour {


	public GameObject player;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (distance(transform.position,player.transform.position) <= 2){
			foreach (Transform child in this.transform) {
				if (child.gameObject.name != "Initial")
					child.gameObject.SetActive (true);
			}

			//yield return new WaitForSeconds (5);
			//Application.LoadLevel("Scenes/WaterLevel");
            SceneManager.LoadScene("Low_poly_Level");

		}
	}

	// Calculate distance between NPC and Tim
	float distance(Vector3 currentPos, Vector3 target){

		return Mathf.Sqrt (Mathf.Pow(target.x - currentPos.x,2) + Mathf.Pow(target.y - currentPos.y,2) + Mathf.Pow(target.z - currentPos.z,2));
	}
}
