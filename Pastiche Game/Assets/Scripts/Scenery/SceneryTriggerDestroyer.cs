using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneryTriggerDestroyer : MonoBehaviour {

	// ------------------------------------
	// Methods
	// ------------------------------------
	void OnTriggerEnter(Collider col) {
		Debug.Log ("collide");
		// If an object to be destroyed enters the trigger
		if (col.tag == "SceneryDestroy") {
			// Destroy it
			Destroy(col.gameObject);
		}
	}

}
