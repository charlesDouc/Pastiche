using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreController : MonoBehaviour {

	// public variables


	// private variables
	

	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
	}

	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {

		Vector3 currentPos = transform.position;
		currentPos.z  -= 20f;
		
		transform.position = currentPos;
	}


}
