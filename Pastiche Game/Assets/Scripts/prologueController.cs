using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prologueController : MonoBehaviour {

	// public variables

	// private variables
	private GameObject m_theConsole;		// GameObject to send function to the cconsole

	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
		// Get the console game object
		m_theConsole = GameObject.FindGameObjectWithTag("Console");

		// Get the script of the console
		ConsoleView consoleScript = m_theConsole.GetComponent<ConsoleView>();
		consoleScript.bootUp();
	}
		
	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {

		
	}

	// ------------------------------------
	// Methods
	// ------------------------------------

}
