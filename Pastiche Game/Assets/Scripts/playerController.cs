using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	// public variables
	public float m_movementSpeed = 25f;		// Movement speed of the object

	// private variables
	private bool m_move = false;			// Check if object is in movement
	private bool m_goRight = false;			// Go right direction
	private bool m_goLeft = false;			// Go left direction
	private bool m_goUp = false;			// Go up direction
	private bool m_goDown = false;		// Go bottom direction


	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {
		Vector3 currentPos = transform.position;

		// Check if the object is in movement
		if (m_move) {
			// Check if the object is going right
			if (m_goRight) {
				currentPos.x += m_movementSpeed;
				// Update the position of the object
				transform.position = currentPos;
			}

			// Check if the object is going left
			if (m_goLeft) {
				currentPos.x -= m_movementSpeed;
				// Update the position of the object
				transform.position = currentPos;
			}

			// Check if the object is going Up
			if (m_goUp) {
				currentPos.y += m_movementSpeed;
				// Update the position of the object
				transform.position = currentPos;
			}

			// Check if the object is going down
			if (m_goDown) {
				currentPos.y -= m_movementSpeed;
				// Update the position of the object
				transform.position = currentPos;
			}
		}



		
	}

	// ------------------------------------
	// Methods
	// ------------------------------------
	public void goRight () {
		// Make sure the object is not in movement
		if (!m_move) {
			// Start right Movement
			m_goRight = true;
			m_move = true;
		}
	}

	public void goLeft () {
		// Make sure the object is not in movement
		if (!m_move) {
			// Start left Movement
			m_goLeft = true;
			m_move = true;
		}
	}

	public void goUp () {
		// Make sure the object is not in movement
		if (!m_move) {
			// Start up Movement
			m_goUp = true;
			m_move = true;
		}
	}

	public void goDown () {
		// Make sure the object is not in movement
		if (!m_move) {
			// Start up Movement
			m_goDown = true;
			m_move = true;
		}
	}

}
