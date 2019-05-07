using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
        //This will launch the Play scene if we are in the game over scene and press enter/return.
		if (Input.GetAxis("Submit") == 1) {
			SceneManager.LoadScene("Play");
		}
	}
}
