using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockerController : MonoBehaviour {

	// public variables
	[Header("Directions")]
	public bool m_allowLeft;				// Allow the player to go left
	public bool m_allowRight;				// Allow the player to go right
	public bool m_allowUp;					// Allow the player to go up
	public bool m_allowDown;				// Allow the player to go down
	public int numberOfPlayer = 0;			// NumberOfplayer in collision


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
