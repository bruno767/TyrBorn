using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour {

	public Vector3 OrbitOrientation;
	public Transform OrbitCenter;
	public int AngularSpeed;
	private static Vector3 NullVector3 = new Vector3 (-9999, 9999, 9999);
	private Vector3 m_AssociatedPlanetPosition;

	// Use this for initialization
	void Start () {
		if (OrbitOrientation == Vector3.zero) {
			OrbitOrientation = Vector3.up;
		}
		m_AssociatedPlanetPosition = NullVector3;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (m_AssociatedPlanetPosition != NullVector3) {
			transform.position += OrbitCenter.transform.position - m_AssociatedPlanetPosition; 
		}
		m_AssociatedPlanetPosition = OrbitCenter.transform.position;

		transform.RotateAround(OrbitCenter.transform.position, OrbitOrientation, Time.deltaTime * AngularSpeed);
	}
}
