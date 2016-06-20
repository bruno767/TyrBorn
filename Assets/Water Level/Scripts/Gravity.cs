using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {
	GameObject m_ParentPlanet;
	[Range(0,50)]
	public float gravityMultiplier;

	// Use this for initialization
	void Start () {
		if (gameObject.tag == "Planet") {
			m_ParentPlanet = this.gameObject;
		} else {
			m_ParentPlanet = FindParentWithTag (this.gameObject, "Planet");
		}

		float parentPlanetRadius = m_ParentPlanet.GetComponent<Collider>().bounds.size.y / 2;


		//init children
		foreach (Transform child in m_ParentPlanet.transform) {

			Rigidbody childRb = child.GetComponent<Rigidbody> ();
			if (childRb != null) {
				childRb.useGravity = false;
			} else if (child.gameObject.tag == "Suffers Gravity" /*&& child.GetComponent<Collider>() != null*/) { // fixes only some vertical misalignment
				Vector3 N = (child.position - m_ParentPlanet.transform.position).normalized;
				child.up = N;
				Debug.DrawRay (child.position, N);
				//float childHeight = child.GetComponent<Collider>().bounds.size.y;
				//child.position = m_ParentPlanet.transform.position + N * (parentPlanetRadius);			
			}
		}

	}

	void FixedUpdate (){
		foreach (Transform child in transform) {
			if (child.gameObject.tag == "VerticallyAligned") {
				Vector3 N = (child.position - m_ParentPlanet.transform.position).normalized;
				Rigidbody childRb = child.GetComponent<Rigidbody> ();
				if (childRb != null) {
					childRb.useGravity = false;
					childRb.AddForce (childRb.mass * gravityMultiplier * -N);
					child.up = N;
				}
			}
		}
	}

	public static GameObject FindParentWithTag(GameObject childObject, string tag)
	{	
		Transform t = childObject.transform;
		while (t.parent != null)
		{
			if (t.parent.tag == tag)
			{
				return t.parent.gameObject;
			}
			t = t.parent.transform;
		}
		return null; // Could not find a parent with given tag.
	}

}
