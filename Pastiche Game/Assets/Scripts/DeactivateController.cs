using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateController : MonoBehaviour {

	// public variables
	public GameObject[] m_objectsToDeactivate;

	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
		for (int i = 0; i < m_objectsToDeactivate.Length; i++) {
			m_objectsToDeactivate[i].SetActive(false);
		}
		
	}
}
