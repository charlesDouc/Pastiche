using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour {

    //	public Material[] mat;
    public bool IsExploding = false;
   public  int CurrentlyCollidingSameColoredBalls = 0;
    public List<Transform> AllSameColoredBallsImCollidingWith = new List<Transform>();

	// Use this for initialization
	void Start () {
//
//		int chosenMaterial = Random.Range (0, mat.Length);
//		Debug.Log("Chosen material index is: " + chosenMaterial);
//		GetComponent<Renderer> ().material = mat [chosenMaterial];

	}

	// Update is called once per frame
	void Update () {
		
	}


	void OnCollisionEnter(Collision col){

        //		Debug.Log ("Ball has collided with" + col.transform.tag);

        Debug.Log("The contact impulse is: " + col.impulse.magnitude);
        

        if ((col.transform.tag == "Wall") || (col.transform.tag == "Ball")) {
			GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<AudioSource>().Play();
		}

		if (col.transform.tag == "Ball") {
			if (GetComponent<Renderer> ().material.color == col.transform.GetComponent<Renderer>().material.color) {

                CurrentlyCollidingSameColoredBalls++;
                AllSameColoredBallsImCollidingWith.Add(col.transform);
                //Am I part of a 2+ same colored colliding ball chain?
                if (CurrentlyCollidingSameColoredBalls > 1)
                {
                                       
                    Explode();
                }
               
                Debug.Log ("This object has the same material as me");

			}

		}

	}

    public void Explode()
    {
        Debug.Log("Time to explode!");

        GameObject.Find("MainManager").GetComponent<MainManager>().TotalScore++;
        GameObject.Find("MainManager").GetComponent<AudioSource>().Play();

        //Tell my friends to explode
        IsExploding = true;

        foreach (Transform ball in AllSameColoredBallsImCollidingWith)
        {
            
            if(ball.GetComponent<BallBehavior>().IsExploding == false)
            {
                ball.GetComponent<BallBehavior>().Explode();
            }           

        }

        //Explode myself

        Destroy(gameObject);

    }

}
