using UnityEngine;
using System.Collections;
using UnityEngine.UI;  
public class UpdateLives : MonoBehaviour {
 
    public Text livesLeft;
    
    // Allows us to access what is going on in the FPSController. 
    //FPSController controller = new FPSController(); 
    void Start () {
        livesLeft = GetComponent<Text>();  
    }

    void Update () {
        //TODO: Add if statment to go to the endGame state if there is zero lives left. 

        livesLeft.text = GameObject.Find("FPSController.cs").GetComponent<FPSController>().getNumberOfLives().ToString();
        //gameObject.GetComponent<FPSController>().numberOfLivesLeft.ToString();
        //livesLeft.text = controller.getNumberOfLivesLeft().ToString();
    }
}