using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Intro : MonoBehaviour {

	void Start () {
		
	}
	//Image reference URL: http://3.bp.blogspot.com/-sKha5O8j_HE/ThRbMp0-jmI/AAAAAAAAERs/vT4s9ZYmD70/s1600/SilverJetpack.jpg
	void Update () {
        //This will launch the Play scene if we are in the game over scene and press enter/return.
		if (Input.GetAxis("Submit") == 1) {
			SceneManager.LoadScene("Play");
		}
	}
}
