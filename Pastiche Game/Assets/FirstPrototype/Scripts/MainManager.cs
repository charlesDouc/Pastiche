using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour {

	// public variables
    public int Timeleft = 10;
    public int TotalScore;

	// --------------------------------------
	// Use this for initialization
	// --------------------------------------
	void Start () {
		// Start the IEnumerator
		StartCoroutine (CountDown());

	}

	// --------------------------------------
	// Update is called every frame
	// --------------------------------------
    private void Update()
    {
		// Get the text component of this game object
        // GameObject.Find("ScoreLabel").GetComponent<Text>().text = "Score: " + TotalScore;
    }
		
	
	// --------------------------------------
	// Methods
	// --------------------------------------
    IEnumerator CountDown()
    {
		// Begin a while loop until there's no more time
        while(Timeleft > 0)
        {
			// Wait for 1 second than reduce the timeleft by one unit
            yield return new WaitForSeconds(1);
            Timeleft--;
        }
    }

}
