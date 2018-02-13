using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour {

    public int Timeleft = 10;


    public int TotalScore;

    private void Update()
    {
        GameObject.Find("ScoreLabel").GetComponent<Text>().text = "Score: " + TotalScore;
    }

    // Use this for initialization
    void Start () {

        StartCoroutine (CountDown());
		
	}
	

    IEnumerator CountDown()
    {
        while(Timeleft > 0)
        {
            yield return new WaitForSeconds(1);
            Timeleft--;
           

        }
    }

}
