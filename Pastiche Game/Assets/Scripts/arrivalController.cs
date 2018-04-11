using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrivalController : MonoBehaviour {

	// public variables
	[Header("Directions")]
	public bool m_allowLeft;				// Allow the player to go left
	public bool m_allowRight;				// Allow the player to go right
	public bool m_allowUp;					// Allow the player to go up
	public bool m_allowDown;				// Allow the player to go down
	[Header("On Off Materials")]
	public Material m_offArrival;			// Off material state
	public Material m_onArrival;			// On material state
	public bool m_offOnStart = true;		// Off material on start per defaut
	public int numberOfPlayer = 0;			// NumberOfplayer in collision

	// private variables
	private Material m_currentMat; 			// Current material used


	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
		m_currentMat = GetComponent<Renderer>().material;
		
		// Set the current material use
		if (m_offOnStart) {
			GetComponent<Renderer>().material = m_offArrival;
		} else {
			GetComponent<Renderer>().material = m_onArrival;
		}	
	}

	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {
		if (numberOfPlayer >= 2) {
			resetStage();
		}
	}
	
	// ------------------------------------
	// Methods
	// ------------------------------------
	public void activate (bool state) {
		// Change the material state of the arrival
		if (state) {
			GetComponent<Renderer>().material = m_onArrival;
		} else {
			GetComponent<Renderer>().material = m_offArrival;
		}
	}

	void resetStage () {
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

	public void addPlayer(bool entry) {
		if (entry) {
			numberOfPlayer ++;
		}  else {
			numberOfPlayer --;
		}
	} 

}