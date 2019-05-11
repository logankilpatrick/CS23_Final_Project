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
    void Start()
    {
        player = GetComponent<CharacterController> ();
        setLivesTest();
    }
    void setLivesTest()
    {
        LivesText.text = "Jet Pack Energy: " + jetPackEnergy.ToString();

    }
    // Update is called once per frame
    void Update()
    {
        setLivesTest();
        rotationX = Input.GetAxis("Mouse X") * viewSens;
        rotationy = Input.GetAxis("Mouse Y") * viewSens;

        // if (player.isGrounded)
        // {


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
        // }

        if (player.transform.position.y < -10)
        {
            //numberOfLivesLeft = numberOfLivesLeft - 1; //No lives...

            //SceneManager.LoadScene("Game Over");//This needs to go last/ 
            SceneManager.LoadScene("Game Over");
            //player.transform.position = new Vector3(7,4,6);
            //want the player back to starting point. 
        }

        
        moveDirection.y -= (gravity * 7) * Time.deltaTime;

        // Move the controller
        player.Move(moveDirection * Time.deltaTime);
    }


}
