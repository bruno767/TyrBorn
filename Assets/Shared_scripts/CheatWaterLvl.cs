using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class CheatWaterLvl : MonoBehaviour {

	private Text m_Label_Text;
	private InputField m_Command_Field;
	private bool m_isActive;

	void Start(){
		m_Label_Text = GameObject.Find ("Label").GetComponent<Text>();
		m_Command_Field = GameObject.Find ("CommandField").GetComponent<InputField>();
		m_isActive = false;
		m_Label_Text.gameObject.SetActive (false);
		m_Command_Field.gameObject.SetActive (false);

		m_Player = GameObject.Find ("Player");
	}





	// Update is called once per frame
	void FixedUpdate () {
		// toggles feature state and shows/hide text label
		if (Input.GetKeyDown (KeyCode.Backslash)) {
			if (m_isActive = !m_isActive) {
				m_Label_Text.gameObject.SetActive (true);
				m_Command_Field.gameObject.SetActive (true);
			} else {
				m_Label_Text.gameObject.SetActive (false);
				m_Command_Field.gameObject.SetActive (false);
			}
		}


		if(m_isActive && Input.GetKeyDown(KeyCode.Return)){
			char[] separator = { ' ' }; 
			executeCommand (m_Command_Field.text.Split(separator));
			m_Command_Field.text = "";
		}

	}


	private GameObject m_Player;

	void executeCommand(string [] args){
		GameObject player = GameObject.Find ("Player");
	
		switch (args[0]) {
			case "earth":
					GameObject earth = GameObject.Find ("Earth");
					player.transform.position = new Vector3(378.6f,21.96f, 177.99f);
					player.GetComponent<SimpleController>().SetAssociatedPlanet(earth, false);
					break;

			case "mars":
					GameObject mars = GameObject.Find ("Mars");
					player.transform.position = new Vector3(261.27f,20.3f, 117.5f);
					player.GetComponent<SimpleController>().SetAssociatedPlanet(mars, false);
					break;

			case "jupiter":
					GameObject jupiter = GameObject.Find ("Jupiter");
					player.transform.position = new Vector3(78.6f,21.95f, 105.5f);
					player.GetComponent<SimpleController>().SetAssociatedPlanet(jupiter, false);
					break;
			case "saturn":				
					GameObject saturn = GameObject.Find ("Jupiter");
					player.transform.position = new Vector3(60f, 40f, 80f);
					player.GetComponent<SimpleController>().SetAssociatedPlanet(saturn, false);
					break;

			case "island":
					player.transform.position = new Vector3(-220f,190f, -40f);
					player.GetComponent<SimpleController>().SetAssociatedPlanet(null, false);
					break;

			case "rays":
					int rays = Int32.Parse (args [1]);
					player.GetComponent<PlayerController> ().m_raysCounter = rays;
					break;

			case "stars":
					int stars = Int32.Parse (args [1]);
					player.GetComponent<PlayerController> ().m_starsCounter = stars;
					break;

			case "life":
					int life = Int32.Parse (args [1]);
					player.GetComponent<PlayerController> ().health = life;
					break;
				
		}
	
	}
}
