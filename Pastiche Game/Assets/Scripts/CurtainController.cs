using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainController : MonoBehaviour {

	// private variable
	private bool m_move = false;		// Bool to check if moving
	private Vector3 m_currentPos;		// Current position of the object
	private AudioSource m_audio;		// The audio source linked to the object


	
	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {
		m_currentPos = transform.position;
		// Move animation
		if (m_move) {
			m_currentPos.y -= 3f;
		}
		// Destroy the object onece reach a certain point
		if (m_currentPos.y < -1500f) {
			Destroy (gameObject);
		}

		// Update the current position
		transform.position = m_currentPos;
	}

	// ------------------------------------
	// Methods
	// ------------------------------------
	public void startMovement (bool newMove) {
		m_move = newMove;
		m_audio = gameObject.GetComponent<AudioSource>();
		m_audio.Play();
	}

}
