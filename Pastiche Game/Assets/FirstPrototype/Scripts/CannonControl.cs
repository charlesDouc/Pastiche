using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControl : MonoBehaviour {

	// public variables
	public float RotateSpeed;
	public Transform BallPrefab;
	public Transform SpawnPoint;
	public float ShootForce;
	public Material[] mat;
	public Renderer CanonRenderer;

	// --------------------------------------
	// Use this for initialization
	// --------------------------------------
	void Start () {
		// Get the changecolor method
		ChangeColor ();
	}

	// --------------------------------------
	// Update is called once per frame
	// --------------------------------------
	void Update () {

		// Mouvement map right
		if(Input.GetKey(KeyCode.RightArrow)	|| Input.GetKey(KeyCode.D)) {
			// Rotate the canon to the right
			transform.Rotate (new Vector3 (0,0,-RotateSpeed));
		}

		// Mouvement map left
		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
			// Rotate the canon to the left
			transform.Rotate (new Vector3 (0,0,RotateSpeed));
		}

		// Key map for shooting
		if (Input.GetKeyDown (KeyCode.Space) == true) {
			// Create a new ball and stick it to the spawn point
			Transform NewBall = Instantiate (BallPrefab);
			NewBall.position = SpawnPoint.position;
			NewBall.rotation = SpawnPoint.rotation;
			NewBall.GetComponent<Renderer> ().material = CanonRenderer.material;

			// Get the ball shoot in the pointing direction with a certain force
			Vector3 DirectionVector = SpawnPoint.position - transform.position;
			DirectionVector = DirectionVector * ShootForce;
			NewBall.GetComponent<Rigidbody> ().AddForce (DirectionVector);

			// Change color of the canon
			ChangeColor ();
			// Play a shooting sound
			GetComponent<AudioSource> ().Play ();
		}
	}	

	// --------------------------------------
	// Methods
	// --------------------------------------
	void ChangeColor(){
		// Get a random color index and attribute it to the object
		int chosenMaterial = Random.Range (0, mat.Length);	
		CanonRenderer.material = mat [chosenMaterial];
	}

}
