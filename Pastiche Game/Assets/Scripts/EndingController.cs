using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingController : MonoBehaviour {

	// public variables
	public GameObject m_theGM;
	public GameObject m_lastScenery;

	// private variables
	private GameMaster m_GMscript;

	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
		// Get the GMN script
		m_GMscript = m_theGM.GetComponent<GameMaster>();
		
		StartCoroutine("theEnd");
	}

	// ------------------------------------
	// Methods
	// ------------------------------------
	IEnumerator theEnd () {
		yield return new WaitForSeconds(20f);
		m_lastScenery.SetActive(false);
		m_GMscript.theEnd();
		yield return new WaitForSeconds(15f);
		SceneManager.LoadScene(0);
	}

}
