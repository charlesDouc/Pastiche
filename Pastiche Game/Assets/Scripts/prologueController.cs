using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class prologueController : MonoBehaviour {

	// public variables
	public GameObject m_LoadingScreen;		// Loading screen image
	public int m_numberOfBlinkSequence = 5; // Number of time the loading screen will blink
	[Header ("Text Blocks")]
	public GameObject m_textBlockOne;	 	// Text block boot up one
	public GameObject m_textBlockTwo;	 	// Text block boot up one
	public GameObject m_textBlockThree;	 	// Text block boot up one
	public GameObject m_textBlockFour;	 	// Text block boot up one
	public GameObject m_textBlockFive;	 	// Text block boot up one
	public GameObject m_textBlockSix;	 	// Text block boot up one
	public GameObject m_textBlockSeven;	 	// Text block boot up one
	[Header ("Logo")]
	public GameObject m_specterLogo;		// Logo image
	public GameObject m_welcomeTitle;		// Welcome title under the logo


	// private variables

	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
		// Start the boot Sequence
		StartCoroutine("BootUpSequence");
	
	}
		
	// ------------------------------------
	// Methods
	// ------------------------------------
	IEnumerator BootUpSequence () {
		// The blinking animation of the loading screen
		for (int i = 0; i < m_numberOfBlinkSequence + 1; i++) {
			m_LoadingScreen.gameObject.SetActive(true);
			yield return new WaitForSeconds(0.5f);
			m_LoadingScreen.gameObject.SetActive(false);
			yield return new WaitForSeconds(0.5f);
		}

		// Display blocs one after the other
		m_textBlockOne.gameObject.SetActive(true);
		yield return new WaitForSeconds(1);
		m_textBlockTwo.gameObject.SetActive(true);
		yield return new WaitForSeconds(0.1f);
		m_textBlockThree.gameObject.SetActive(true);
		yield return new WaitForSeconds(0.5f);
		m_textBlockFour.gameObject.SetActive(true);
		yield return new WaitForSeconds(0.1f);
		m_textBlockFive.gameObject.SetActive(true);
		yield return new WaitForSeconds(1f);
		m_textBlockSix.gameObject.SetActive(true);
		yield return new WaitForSeconds(0.2f);
		m_textBlockSeven.gameObject.SetActive(true);
		yield return new WaitForSeconds(3f);

		// Deactivate all tex blocks
		m_textBlockOne.gameObject.SetActive(false);
		m_textBlockTwo.gameObject.SetActive(false);
		m_textBlockThree.gameObject.SetActive(false);
		m_textBlockFour.gameObject.SetActive(false);
		m_textBlockFive.gameObject.SetActive(false);
		m_textBlockSix.gameObject.SetActive(false);
		m_textBlockSeven.gameObject.SetActive(false);

		// Specter Logo
		yield return new WaitForSeconds(2f);
		m_specterLogo.gameObject.SetActive(true);
		m_welcomeTitle.gameObject.SetActive(true);

		// Load next scene
		SceneManager.LoadScene(1);

	} 

}
