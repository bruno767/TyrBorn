using UnityEngine;
using System.Collections;

public class LoadNewScene : MonoBehaviour {


	public GameObject player;

	private bool openPortal;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (!openPortal){
			if (player.GetComponent<PlayerController>().m_raysCounter == 4) {
				openPortal = true;

				foreach (Transform child in this.transform) {

					if (child.gameObject.name == "Initial")
						child.gameObject.SetActive (true);
				} 
			}
		}
	}
}
