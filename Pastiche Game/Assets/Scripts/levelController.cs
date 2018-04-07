using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelController : MonoBehaviour {

	// public variables
	public GameObject m_nextLevel;			// Variable to hold next level game object
	public int m_totalOfArrivals;			// Total of arrivals in this level
	public bool m_haveNextLevel = true;		// True if there's a next level (put to false while building)

	// private variables
	private int m_activatedArrivals = 0;	// Total of activated arrivals in this level


	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
		
	}
	
	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {
		// When the number of activated arrivals equal the total of arrivals in the level
		if (m_activatedArrivals == m_totalOfArrivals && m_haveNextLevel) {
			// Activate next level and desactivate the current one
			m_nextLevel.SetActive(true);
			gameObject.SetActive(false);
		}	
	}
	
	// ------------------------------------
	// Methods
	// ------------------------------------
	public void newEntry (bool add) {
		// If the adjustement is adding, add value to the activated arrivals
		if (add) {
			m_activatedArrivals ++;
		// If not adding, substract value from the activated arrivals
		} else {
			m_activatedArrivals --;
		}
	}

	public void resetLevel () {
		// Get all the players object active in the scene
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

		// Activate the movement for each player instance
		if (players != null) {
			for (int i = 0; i < players.Length; i++) {
				playerController playersScript = players[i].GetComponent<playerController>();
				playersScript.reset();
			}
		}
	}

}
