using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWon : MonoBehaviour
{
    void Start () {
		
	}
	//Image reference URL: https://fthmb.tqn.com/LP4_NoRsJCWGS0tIGa0vEBAru9o=/4256x2832/filters:fill(auto,1)/low-angle-view-of-firework-display-over-river-during-sunset-604213021-57752e7b3df78cb62c11aba4.jpg
	void Update () {
        //This will launch the Play scene if we are in the game over scene and press enter/return.
		if (Input.GetAxis("Submit") == 1) {
			SceneManager.LoadScene("Play");
		}
	}
}
