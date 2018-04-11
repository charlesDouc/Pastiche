using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderController : MonoBehaviour {

	// public variables
	public bool m_Xaxis = true;
	public bool m_Yaxis	= false;
	public float m_speed = 2f;

	// private variables
	private bool m_startAnimation = false;
	private Vector3 m_currentPos;


	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {
		if (m_startAnimation) {
			m_currentPos = transform.position;

			// If moving on the X axix
			if (m_Xaxis) {
				m_currentPos.x += m_speed;
			}
			if (m_Yaxis) {
				m_currentPos.y += m_speed;
			}

			// Update the position of the object
			transform.position = m_currentPos;
		}
	}

	// ------------------------------------
	// Methods
	// ------------------------------------
	public void startAnimation () {
		m_startAnimation = true;
		StartCoroutine ("autoDestroy");
	}

	IEnumerator autoDestroy () {
		// After some time, destroy the object
		yield return new WaitForSeconds(20);
		Destroy(gameObject);
	}

}
