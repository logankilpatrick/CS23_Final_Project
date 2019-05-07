using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public float numberOfLivesLeft = 3.0f;

    private Vector3 moveDirection = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController> ();
    }

    // Update is called once per frame
    void Update()
    {
        rotationX = Input.GetAxis("Mouse X") * viewSens;
        rotationy = Input.GetAxis("Mouse Y") * viewSens;

        if (player.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= movementSpeed;

            transform.Rotate(0, rotationX, 0);
            playerView.transform.Rotate(-rotationy, 0, 0); //makes the looking control not inverted. 
            moveDirection = transform.rotation * moveDirection;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        //makes the looking control not inverted. 
        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (player.transform.position.y < -10)
        {
            SceneManager.LoadScene("Game Over");
            numberOfLivesLeft -= 1;
        }

        
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        player.Move(moveDirection * Time.deltaTime);
    }


}
