using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControl : MonoBehaviour {

	public float RotateSpeed;
	public Transform BallPrefab;
	public Transform SpawnPoint;
	public float ShootForce;
	public Material[] mat;
	public Renderer CanonRenderer;

	// Use this for initialization
	void Start () {
		
		ChangeColor ();
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.RightArrow)==true){

			transform.Rotate (new Vector3 (0,0,-RotateSpeed));

		}
		if(Input.GetKey(KeyCode.LeftArrow)==true){

			transform.Rotate (new Vector3 (0,0,RotateSpeed));

		}
		if (Input.GetKeyDown (KeyCode.Space) == true) {

			Transform NewBall = Instantiate (BallPrefab);
			NewBall.position = SpawnPoint.position;
			NewBall.rotation = SpawnPoint.rotation;
			NewBall.GetComponent<Renderer> ().material = CanonRenderer.material;

            Vector3 DirectionVector = SpawnPoint.position - transform.position;
            DirectionVector = DirectionVector * ShootForce;
            NewBall.GetComponent<Rigidbody>().AddForce(DirectionVector);

			ChangeColor();
            GetComponent<AudioSource>().Play();
		}


	
	}	

	void ChangeColor(){

		int chosenMaterial = Random.Range (0, mat.Length);	
		CanonRenderer.material = mat [chosenMaterial];
	}

}
