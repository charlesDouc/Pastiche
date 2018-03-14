using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeoController : MonoBehaviour {

	// public variables
	public float m_rotationSpeed = 500f;
	public float m_refreshRotate = 0.1f;

	// private variables

	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
		// Start the rotation animation
		StartCoroutine(rotate());
	}

	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {

	}

	// ------------------------------------
	// Methods
	// ------------------------------------
	private IEnumerator rotate () {
		// Create a float variable that make the object rotate on an axis
		float step = m_rotationSpeed * Time.deltaTime;

		// Don't rotate the object fluidly. Refresh it after some time
		while (true) {
			gameObject.transform.Rotate (0, 0, step);
			// Return the value depending on a time lapse
			yield return new WaitForSeconds (m_refreshRotate);
		}
	}

}
