﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting : MonoBehaviour
{

    //Not currently in use. 
    public Transform teleportTarget; 
    public GameObject thePlayer; 

    void OnTriggerEnter(Collider other)
    {
        thePlayer.transform.position = teleportTarget.transform.position;
    }
    
}
