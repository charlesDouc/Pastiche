using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneryTwo : MonoBehaviour {

	// public variables
	public GameObject m_leftBorder;			// Game object on the left border
	public GameObject m_rightBorder;		// Game object on the right border

	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
		// Get the script of the two borders
		BorderController leftBorderScript = m_leftBorder.GetComponent<BorderController>();
		BorderController rightBorderScript = m_rightBorder.GetComponent<BorderController>();
		// Start Animation
		leftBorderScript.startAnimation();
		rightBorderScript.startAnimation();		
	}
}
