using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputFieldController : MonoBehaviour {

	// public variables

	// private variables
	private InputField m_input;

	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
		// Get the input field of the object
		m_input = gameObject.GetComponent<InputField>();
	}

	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {
		// Always keep it activated
		m_input.ActivateInputField();
	}

	// ------------------------------------
	// Methods
	// ------------------------------------

}
