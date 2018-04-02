using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeController : MonoBehaviour {

	// public variables
	public bool m_goingDown = false;		// Check the direction of the object
	public float m_speedDirection = 3f;		// Speed value of the object on the line
	public float m_refreshMovement = 0.1f;  // Value of the update refresher
	public GameObject m_levelManager;		// Get the level manager

	// private variables
	private Vector3 m_currentPos;			// Use to capture the data of the object's position
	private bool m_isMoving = false;		// Make the object moves

	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {

		// Start Coroutine for the movement
		StartCoroutine(move());

	}

	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {
		// Capture current position of the object
		m_currentPos = transform.position;


		// Check the direction of the object
		if (m_goingDown && m_isMoving) {
			// Invert the speed direction if it necessary
			m_speedDirection = m_speedDirection * -1;
			// Make sure this doesn't get repeated
			m_goingDown = false;

		// Otherwise, while moving, change the position data of the object
		} else if (m_isMoving) {
			m_currentPos.y += m_speedDirection;
		}
	}

	// ------------------------------------
	// Methods
	// ------------------------------------
	private IEnumerator move () {
		// Don't rotate the object fluidly. Refresh it after some time
		while (true) {
			// Return the value depending on a time lapse
			yield return new WaitForSeconds (m_refreshMovement);
			// Update the position of the object if it's moving
			if (m_isMoving) {
				transform.position = m_currentPos;
			}
		}
	}

	void OnTriggerEnter (Collider col) {
		// If the object collides with the blocker
		if (col.gameObject.tag == "Blocker") {
		 	//Debug.Log ("contact");

			// Stop the cube movement
			m_isMoving = false;

			// Add the cube in the blocker object
			blockerController blockerScript = col.gameObject.GetComponent<blockerController> ();
			blockerScript.addedCube ();

			// Said to the level that the line is complete
			levelController levelScript = m_levelManager.GetComponent<levelController>();
			levelScript.lineCompleted();
		}
	}

	public void readyToMove () {
		// Make the object readyToMove
		m_isMoving = true;
	}
		
}
