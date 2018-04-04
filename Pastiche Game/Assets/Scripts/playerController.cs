using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	// public variables
	public float m_movementSpeed = 25f;		// Movement speed of the object
	public GameObject m_levelManager;		// The level manager in which the object lives

	// private variables
	private bool m_move = false;			// Check if object is in movement
	private bool m_goRight = false;			// Go right direction
	private bool m_goLeft = false;			// Go left direction
	private bool m_goUp = false;			// Go up direction
	private bool m_goDown = false;			// Go bottom direction
	private bool m_canGoLeft = true;		// Allow the player to go left
	private bool m_canGoRight = true;		// Allow the player to go right
	private bool m_canGoUp = true;			// Allow the player to go up
	private bool m_canGoDown = true;		// Allow the player to go down


	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void FixedUpdate () {
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
	void OnTriggerEnter (Collider col)  {
		// When the object collides with a blocker
		if (col.tag == "Blocker") {
			// Reset all movements and inputs
			m_move = false;
			m_goRight = false;
			m_goLeft = false;
			m_goUp = false;
			m_goDown = false;

			// Get the directions value from the blocker
			blockerController blockerScript = col.gameObject.GetComponent<blockerController>();
			m_canGoRight = blockerScript.m_allowRight;
			m_canGoLeft = blockerScript.m_allowLeft;
			m_canGoUp = blockerScript.m_allowUp;
			m_canGoDown = blockerScript.m_allowDown;
		}

		// When the object collides with the Arrival
		if (col.tag == "Arrival") {
			// Reset all movements and inputs
			m_move = false;
			m_goRight = false;
			m_goLeft = false;
			m_goUp = false;
			m_goDown = false;

			// Get the directions value from the arrival
			arrivalController arrivalScript = col.gameObject.GetComponent<arrivalController>();
			m_canGoRight = arrivalScript.m_allowRight;
			m_canGoLeft = arrivalScript.m_allowLeft;
			m_canGoUp = arrivalScript.m_allowUp;
			m_canGoDown = arrivalScript.m_allowDown;
		}
	} 


	public void goRight () {
		// Make sure the object is not in movement
		if (!m_move && m_canGoRight) {
			// Start right Movement
			m_goRight = true;
			m_move = true;
		}
	}

	public void goLeft () {
		// Make sure the object is not in movement
		if (!m_move && m_canGoLeft) {
			// Start left Movement
			m_goLeft = true;
			m_move = true;
		}
	}

	public void goUp () {
		// Make sure the object is not in movement
		if (!m_move && m_canGoUp) {
			// Start up Movement
			m_goUp = true;
			m_move = true;
		}
	}

	public void goDown () {
		// Make sure the object is not in movement
		if (!m_move && m_canGoDown) {
			// Start up Movement
			m_goDown = true;
			m_move = true;
		}
	}

}
