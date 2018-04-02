using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockerController : MonoBehaviour {

	// public variables
	public bool m_goingDown = true;			// Check the direction of the object
	public float m_speedDirection = 0.5f;	// Speed value of the object on the line
	public float m_refreshMovement = 0.1f;  // Value of the update refresher
	public Material m_Activate;				// The changing material

	// private variables
	private int m_numberOfCubes;			// Number of cubes stacking under the blocker
	private Vector3 m_currentPos;			// Use to capture the data of the object's position
	private bool m_isMoving = false;		// Make the object moves
	private MeshRenderer m_renderer;		// A variable linked to the mesh renderer



	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
		// Fresh start without cubes
		m_numberOfCubes = 0;
		// Link the renderer
		m_renderer = gameObject.GetComponent<MeshRenderer>();

		// Start Coroutine for the movement
		StartCoroutine(move());
		
	}

	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {
		// Capture current position of the object
		m_currentPos = transform.position;


		// Check the direction of the object
		if (m_goingDown && m_isMoving) {
			// Invert the speed direction if it necessary
			m_speedDirection = m_speedDirection * -1;
			// Make sure this doesn't get repeated
			m_goingDown = false;
		
		
		// Otherwise, while moving, change the position data of the object
		} else if (m_isMoving) {
			m_currentPos.y += m_speedDirection;
		}
			

		// If there's 3 cubes pushing the blocker, destroy it
		if (m_numberOfCubes == 3) {
			Destroy (gameObject);
		}
			
	}
		
	// ------------------------------------
	// Methods
	// ------------------------------------
	private IEnumerator move () {
		// Don't rotate the object fluidly. Refresh it after some time
		while (true) {
			// Return the value depending on a time lapse
			yield return new WaitForSeconds (m_refreshMovement);
			// Update the position of the object if it's moving
			if (m_isMoving) {
				transform.position = m_currentPos;
			}
		}
	}

	public void addedCube () {
		// Stop all movement of the object
		m_isMoving = false;
		// Change the material of the object
		m_renderer.material = m_Activate;


		// Add a cube to the counter
		m_numberOfCubes ++;
	}



}
