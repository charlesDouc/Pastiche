using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelController : MonoBehaviour {

	// public variables
	public GameObject m_nextLevel;			// Variable to hold next level game object
	public int m_totalOfArrivals;			// Total of arrivals in this level
	public bool m_haveNextLevel = true;		// True if there's a next level (put to false while building)
	[Header("End direction Speed")]
	public float m_ySpeed = 10f;			// End animation y spedd direction
	public float m_zSpeed = 3f;				// End animation y spedd direction
	public float m_timeLapse = 3f;			// Time before activating next stage;	

	// private variables
	private int m_activatedArrivals = 0;	// Total of activated arrivals in this level
	private GameObject m_theGameMaster;		// Instance of the Game Master
	private GameMaster m_GMcontroller;		// Script attach to the game master
	private bool levelFinished = false;		// Indicate the state of the stage
	private Vector3 m_currentPos; 			// Current pos of the object
	private bool m_startEndAnim = false;	// Check for the end animation 

	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
		// Initiate the Game Master
		m_theGameMaster = GameObject.FindWithTag("GameController");
		m_GMcontroller = m_theGameMaster.GetComponent<GameMaster>();
	}
	
	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {
		// When the number of activated arrivals equal the total of arrivals in the level
		if (m_activatedArrivals == m_totalOfArrivals && m_haveNextLevel	&& !levelFinished) {
			// Activate next level and desactivate the current one
			StartCoroutine("startTransition");
			levelFinished = true;
		}	

		// Movement animation at the end of a level
		if (levelFinished && m_startEndAnim) {
			m_currentPos = transform.position;
			m_currentPos.z -= m_ySpeed;
			m_currentPos.y -= m_zSpeed;
			transform.position = m_currentPos;
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

	IEnumerator startTransition () {
		m_GMcontroller.startTransition();
		yield return new WaitForSeconds(2f);
		m_startEndAnim = true;
		yield return new WaitForSeconds(m_timeLapse);
		// Turn off this level and activate next level
		m_nextLevel.SetActive(true);
		// Tell the GM the transition is over
		m_GMcontroller.endTransition();
		gameObject.SetActive(false);
	}

}
