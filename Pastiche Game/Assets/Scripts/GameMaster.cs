using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

	// public variables
	public GameObject m_theConsole;			// Instance of the console to display messages
	public GameObject m_inputCommands;		// Game Object of the input bar
	public GameObject m_backCurtain;		// Back curtain to hide scene
	[Header("Audio System")]
	public AudioSource m_audio; 			// Audio source
	public AudioSource m_audioTwo; 			// Second Audio source
	public AudioClip m_bipSound;			// Bip Sound
	public AudioClip m_transitionSound;		// Transition sound



	// private variables
	private ConsoleView m_consoleScript;	// Reference to the script of the console viewer
	private int numberOfMove = 0;			// Player Score


	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
		// Search the script of the console
		m_consoleScript = m_theConsole.GetComponent<ConsoleView>();

		// Initial messages
		StartCoroutine("initialSequence");
	}

	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {
		// EachTime player hit start
		if (Input.GetKeyDown(KeyCode.Return)) {
			// Update player's score
			numberOfMove ++;
		}
		// Escape command
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
		
	}

	// ------------------------------------
	// Methods
	// ------------------------------------
	IEnumerator initialSequence () {
		// Initial sequence on the console
		yield return new WaitForSeconds(0.5f);
		m_consoleScript.initialSequence(1);
		
		yield return new WaitForSeconds(3f);
		// Play a bip sound
		m_audio.clip = m_bipSound;
		m_audio.Play();
		m_consoleScript.initialSequence(2);
		
		yield return new WaitForSeconds(1f);
		m_consoleScript.initialSequence(3);

		yield return new WaitForSeconds(3f);
		m_consoleScript.initialSequence(4);

		yield return new WaitForSeconds(0.5f);
		m_consoleScript.initialSequence(5);

		yield return new WaitForSeconds(3f);
		// Activate the visual
		CurtainController curtainScript = m_backCurtain.GetComponent<CurtainController>();
		curtainScript.startMovement(true);
		m_consoleScript.initialSequence(6);

		yield return new WaitForSeconds(6f);
		// Activating the command input
		inputFieldController inputScript = m_inputCommands.GetComponent<inputFieldController>();
		inputScript.changeStatus(true);
		m_consoleScript.initialSequence(7);
	}

	public void startTransition () {
		// Disable input command
		inputFieldController inputScript = m_inputCommands.GetComponent<inputFieldController>();
		inputScript.changeStatus(false);
		// Show a message in the console
		m_consoleScript.successSequence(1);
		// Play transition sound
		m_audio.clip = m_transitionSound;
		m_audio.Play();
	}

	public void endTransition () {
		// Enable input command
		inputFieldController inputScript = m_inputCommands.GetComponent<inputFieldController>();
		inputScript.changeStatus(true);
		// Show a message in the console
		m_consoleScript.successSequence(2);
		m_audioTwo.clip = m_bipSound;
		m_audioTwo.Play();
	}

	public void newEnvironment (int index) {
		 // Show a message
		m_consoleScript.newEnvironment(index);
	}

	public void theEnd () {
		// Disable input command
		inputFieldController inputScript = m_inputCommands.GetComponent<inputFieldController>();
		inputScript.changeStatus(false);
		m_audioTwo.clip = m_bipSound;
		m_audioTwo.Play();

		m_consoleScript.final(numberOfMove);
	}
}
