using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonController : MonoBehaviour {

	// public variables
	public GameObject[] m_rows;


	// private variables
	private int m_currentRow;

	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
		// Set the current angle of the canon to 0
		m_currentRow = 0; 
	}

	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {

	}

	// ------------------------------------
	// Methods
	// ------------------------------------
	public void changeAngle (int newRow) {
		// Change the angle of the canon to a new value
		m_currentRow = newRow;
	}

	public void shoot () {
		
	}

}
