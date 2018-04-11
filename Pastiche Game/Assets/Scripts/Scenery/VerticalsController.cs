using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalsController : MonoBehaviour {

	// public variables
	public float m_speed = 25f;				// Movement speed

	// private variables
	private bool m_isMoving = true;

	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {
		if (m_isMoving) {
			Vector3 currentScale = transform.localScale;

			if (currentScale.x < 51521.23f) {
				currentScale.x += m_speed;
			} else {
				m_isMoving = false;
			}

			transform.localScale = currentScale;
		}
	}
}
