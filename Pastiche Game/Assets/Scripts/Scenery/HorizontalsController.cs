using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalsController : MonoBehaviour {

	// public variables
	public float m_speed = 25f;		// Speed movement;

	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {
		// Catch current position
		Vector3 currentPos = transform.position;

		// increase valu
		currentPos.z -= m_speed;

		// Update position
		transform.position = currentPos;

		// Destroy the object after a certain point
		if (currentPos.z < -23905f) {
			Destroy (gameObject);
		}
	}
}
