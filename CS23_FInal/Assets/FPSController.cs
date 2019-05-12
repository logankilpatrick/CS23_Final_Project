using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  

public class FPSController : MonoBehaviour
{
    public float movementSpeed = 6f;
    float FB_Move; //forward and backwords movement
    float LR_Move; //Left right movement

    public float viewSens = 15f;
    float rotationX;
    float rotationy;

    CharacterController player;
    public GameObject playerView;

    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    // Start is called before the first frame update
    //public int numberOfLivesLeft = 3;
    public int jetPackEnergy = 100;
    public Text LivesText;

    public float timeLeft = 120.0f;
    public Text timeText; 

    void Start()
    {
        player = GetComponent<CharacterController> ();
        setLivesTest();
    }
    void setLivesTest()
    {
        LivesText.text = "Jet Pack Energy: " + jetPackEnergy.ToString();
    }
    private void OnTriggerExit(Collider other)
    {
        //Switch statement switching on the name of the collider will work too. 
        if ((other.gameObject.name == "JetPack Re-Fuel")  && jetPackEnergy <= 2000)
        {
            jetPackEnergy = jetPackEnergy + 100;
            setLivesTest();        
        }
        else if ((other.gameObject.name == "JetPack Re-Fuel") && jetPackEnergy <= 300) //Level 1 refuel location
        {
            jetPackEnergy = jetPackEnergy + 100;
            setLivesTest();        
        }
        else if ((other.gameObject.name == "JetPack Re-Fuel2") && jetPackEnergy <= 300) //Level 2 refuel location
        {
            jetPackEnergy = jetPackEnergy + 50;
            setLivesTest();        
        }
        else if ((other.gameObject.name == "JetPack Re-Fuel3") && jetPackEnergy <=425) //Level 2 refuel location
        {
            jetPackEnergy = jetPackEnergy + 25;
            setLivesTest();        
        }
        else if (other.gameObject.name == "YouWon")
        {
            SceneManager.LoadScene("You Won");
        }
        else if (other.gameObject.name == "Enemy(P 1)" || other.gameObject.name == "Enemy(P 4)")
        {
            jetPackEnergy = jetPackEnergy - 10;
            //can have postive fuel if they are fuel helpers...
            //...or negative fuel if they are enemies. 
        }
    }

    // Update is called once per frame
    void Update()
    {
        setLivesTest();
        rotationX = Input.GetAxis("Mouse X") * viewSens;
        rotationy = Input.GetAxis("Mouse Y") * viewSens;

        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveDirection *= movementSpeed;

        transform.Rotate(0, rotationX, 0);
        playerView.transform.Rotate(-rotationy, 0, 0); //makes the looking control not inverted. 
        moveDirection = transform.rotation * moveDirection;

        if (Input.GetButton("Jump") && jetPackEnergy > 0)
        {
            moveDirection.y = jumpSpeed;
            jetPackEnergy = jetPackEnergy - 1;
        }
       

        if (player.transform.position.y < -100) //This value starts couting when the player leaves a ground.  So if they fall for more than
        {                                       // 100 unit of measure, the game will end since they passed out. 

            //numberOfLivesLeft = numberOfLivesLeft - 1; //No lives... You've got one shot. 
            //SceneManager.LoadScene("Game Over");//This needs to go last/ 
            SceneManager.LoadScene("Game Over");
            //player.transform.position = new Vector3(7,4,6);
            //want the player back to starting point. 
        }

        timeLeft -= Time.deltaTime;
        timeText.text = "Time Remaining: " + (timeLeft).ToString("0");

        if (timeLeft < 0)
        {
            SceneManager.LoadScene("Game Over");
        }

        
        moveDirection.y -= gravity * Time.deltaTime * 7;

        // Move the controller
        player.Move(moveDirection * Time.deltaTime);
    }


}
