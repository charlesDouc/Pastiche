using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelController : MonoBehaviour {

	// public variables
	public GameObject[] m_projectiles;		// Objects to shoot
	public GameObject m_cannon;				// The cannon object
	public float m_refreshMovement = 0.1f;  // Value of the update refresher
	public float m_speed = 10f;				// Speed of movement
	public int m_numberOfLines;				// Number of lines to complete the level
	public GameObject m_nextLevel;			// Game object of the next level

	// private variables
	private Vector3 m_currentPos;			// Use to capture the data of the object's position
	private bool m_isMoving = false;		// Make the object moves
	private int m_selectedColumns = 0;		// The colomn index
	private int m_linesCompleted = 0;		// Completed lines


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
		m_currentPos = transform.position;

		cannonController cannonData = m_cannon.GetComponent<cannonController>();
		m_selectedColumns = cannonData.m_columns;

		if (cannonData.m_fired) {
			if (m_selectedColumns == 1) {
				m_projectiles[0].SetActive(true);
				cannonData.m_fired = false;
			}

			if (m_selectedColumns == 2) {
				m_projectiles[1].SetActive(true);
				cannonData.m_fired = false;
			}
		}

		// The zoom effect when a new level is spawn
		if (m_currentPos.z > 450) {
			m_currentPos.z -= m_speed * 2; 
		} 

		// Load the next level
		if (m_linesCompleted == m_numberOfLines) {
			m_isMoving = true;
			StartCoroutine(nextLevel());
		}
		// Start the zoom effect toward the camerbraa
		if (m_isMoving) {
			m_currentPos.z -= m_speed;
		}


		// After some time, destroy the object
		if (m_currentPos.z < -700) {
			Destroy (gameObject);
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
			// Update the position of the object
			transform.position = m_currentPos;
		}
	}

	public void lineCompleted() {
		m_linesCompleted ++;
	}

	IEnumerator nextLevel () {
		yield return new WaitForSeconds (1);
		m_nextLevel.SetActive(true);
	}
}
