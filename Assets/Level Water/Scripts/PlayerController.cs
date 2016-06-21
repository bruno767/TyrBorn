﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[Range(0,999)]
	public int m_raysCounter;
	[Range(0,5)]
	public int m_starsCounter;
	[Range(0,8)]
	public int m_lifeCounter;

	private Animator anim;
	private int health = 100;

	private bool showDamage;
	public AudioClip musicClip;

	void Start(){
		m_raysCounter = 0;
		m_starsCounter = 0;
		m_lifeCounter = 8;

		anim = GameObject.Find ("main_caracter").GetComponent<Animator> ();
	}
		

	void Update(){

		m_lifeCounter = health * 8 / 100;

		if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle")){
			if (Input.GetMouseButtonDown (1)) {
				anim.SetTrigger ("attackSword1");
			} else if (Input.GetMouseButtonDown(0)){
			}
		}
	}

	void OnTriggerEnter(Collider col){

		if (col.gameObject.name == "RighHand" || col.gameObject.name == "LeftHand") {
			if (col.gameObject.GetComponentInParent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Attack"))
				health -= 5;
		} else if (col.gameObject.tag == "Hearth") {

			if (health + 20 >= 100) {
				health = 100;
			} else {
				health += 20;
			}

			Destroy (col.gameObject);
		} else if (col.gameObject.tag == "Light") {
			m_raysCounter++;
			Destroy (col.gameObject);
		} else if (col.gameObject.tag == "Soul") {
			m_starsCounter++;

			this.GetComponent<AudioSource> ().PlayOneShot (musicClip,0.7f);
			Destroy (col.gameObject);
		}
	}

}
