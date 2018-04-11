using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneryOneController : MonoBehaviour {

	// public variables
	public GameObject m_horizontalPrefab;	// Prefab to be spawn
	public GameObject m_backHorizontal;		// Game object for the back horizontal ()


	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
		// Start coroutine spawning horizontals
		StartCoroutine("spawnHorizontal");
		
	}

	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {
		
	}

	// ------------------------------------
	// Methods
	// ------------------------------------
	IEnumerator spawnHorizontal () {
		while(true) {
			// Instantiate a horizontal line each X seconds
			Instantiate (m_horizontalPrefab, gameObject.transform);
			yield return new WaitForSeconds(3);
		}
	}

}
