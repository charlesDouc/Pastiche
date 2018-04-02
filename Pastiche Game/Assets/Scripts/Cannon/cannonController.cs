using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonController : MonoBehaviour {

	// public variables
	public int m_rows;
	public int m_columns;
	public bool m_fired = false;

	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
		// Set the current angle of the canon to 0
		m_rows = 0; 
		m_columns = 0;
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
		m_columns = newRow;
	}

	public void shoot () {
		if (m_rows != 0 || m_columns != 0) {
			m_fired = true;
		}
	}

}
