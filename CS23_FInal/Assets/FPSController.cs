using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    public float movementSpeed = 2f;
    float FB_Move; //forward and backwords movement
    float LR_Move; //Left right movement

    public float viewSens = 15f;
    float rotationX;
    float rotationy;

    CharacterController player;
    public GameObject playerView;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController> ();
    }

    // Update is called once per frame
    void Update()
    {
        FB_Move = Input.GetAxis("Vertical") * movementSpeed;
        LR_Move = Input.GetAxis("Horizontal") * movementSpeed;

        rotationX = Input.GetAxis("Mouse X") * viewSens;
        rotationy = Input.GetAxis("Mouse Y") * viewSens;


        Vector3 movement = new Vector3(LR_Move, 0, FB_Move);
        transform.Rotate(0, rotationX, 0);
        playerView.transform.Rotate(-rotationy, 0, 0);
        movement = transform.rotation * movement;

        player.Move(movement * Time.deltaTime);
    }
}
