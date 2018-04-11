
/// ------------------------------------------------------------------------------------ 
/// 
/// This script is an asset for the fake console used in my game.
/// Tutorial to put it all together is available at this adress: 
/// https://wwww.packtpub.com/books/content/making-game-console-unity-part-1
/// 
/// I've tried different method, but this one seems to be the most efficient.
/// It takes a little time to understand how it works, but at the end it's pretty simple.
/// 
/// CREDIT :
/// Handles parsing and execution of console commands, as well as collecting log output.
/// Copyright (c) 2014-2015 Eliot Lash
/// 
/// ------------------------------------------------------------------------------------ 

using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Collections;

public class ConsoleView : MonoBehaviour {

	// private variables
	ConsoleController console = new ConsoleController();
	bool didShow = false;

	// public variables
	public GameObject viewContainer; //Container for console view, should be a child of this GameObject
	public Text logTextArea;
	public InputField inputField;

	// --------------------------------------
	// Use this for initialization
	// --------------------------------------
	void Start() {
		if (console != null) {
			console.visibilityChanged += onVisibilityChanged;
			console.logChanged += onLogChanged;
		}
		updateLogStr(console.log);
	}

	~ConsoleView() {
		console.visibilityChanged -= onVisibilityChanged;
		console.logChanged -= onLogChanged;
	}

	// --------------------------------------
	// Update is called once per frame
	// --------------------------------------
	void Update() {
		//Toggle visibility when tilde key pressed
		if (Input.GetKeyUp("`")) {
			toggleVisibility();
		}

		//Toggle visibility when 5 fingers touch.
		if (Input.touches.Length == 5) {
			if (!didShow) {
				toggleVisibility();
				didShow = true;
			}
		}  else {
			didShow = false;
		}
	}
		
	// --------------------------------------
	// Methods
	// --------------------------------------
	void toggleVisibility() {
		setVisibility(!viewContainer.activeSelf);
	}

	void setVisibility(bool visible) {
		viewContainer.SetActive(visible);
	}

	void onVisibilityChanged(bool visible) {
		setVisibility(visible);
	}

	void onLogChanged(string[] newLog) {
		updateLogStr(newLog);
	}

	void updateLogStr(string[] newLog) {
		if (newLog == null) {
			logTextArea.text = "";
		}  else {
			logTextArea.text = string.Join("\n", newLog);
		}
	}

	/// <summary>
	/// Event that should be called by anything wanting to submit the current input to the console.
	/// </summary>
	public void runCommand() {
		console.runCommandString(inputField.text);
		inputField.text = "";
	}


	// MAIN FUNCTIONS FOR TEXT DISPALY ---------------
	public void initialSequence (int messageIndex) {
		// Show the boot up message on the console
		if (messageIndex == 1) {
			console.bootUpMessageOne ();
		}
		if (messageIndex == 2) {
			console.bootUpMessageTwo ();
		}
		if (messageIndex == 3) {
			console.bootUpMessageThree ();
		}
		if (messageIndex == 4) {
			console.bootUpMessageFour ();
		}
		if (messageIndex == 5) {
			console.bootUpMessageFive ();
		}
		if (messageIndex == 6) {
			console.bootUpMessageSix ();
		}
		if (messageIndex == 7) {
			console.bootUpMessageSeven ();
		}
	}

	public void successSequence (int messageIndex) {
		// Show a message in the console view
		if (messageIndex == 1) {
			console.stageComplete ();
		}
		if (messageIndex == 2) {
			console.stageReady ();
		}
	}

	public void newEnvironment (int messageIndex) {
		// Show a message in the console view
		if (messageIndex == 1) {
			console.newEnvOne ();
		}
		if (messageIndex == 2) {
			console.newEnvTwo ();
		}
		if (messageIndex == 3) {
			console.newEnvThree ();
		}
	}

	public void final (int indexScore) {
		console.theEnd (indexScore);
	}



}