using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

	// public variables
	public GameObject m_cannon;


	// private variables


	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
		//console.runCommandString ("hello");
	}

	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {
		
	}

	// ------------------------------------
	// Methods
	// ------------------------------------
	public void canonAngle (int index) {
		cannonController cannonScript = m_cannon.GetComponent<cannonController>();
		cannonScript.changeAngle (index); 
		
	}
}
