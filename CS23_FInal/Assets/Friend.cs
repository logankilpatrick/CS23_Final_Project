using UnityEngine;
using System.Collections;

public class Friend : MonoBehaviour
{
    public float targetDistance = 20;
    public float visionDistance = 20;
    public float attackDistance = 15;
    public float enemyMovementSpeed = 6;
    public float damping = 5;
    public Transform fpsTarget;
    Rigidbody rigidBodyHolder;
    Renderer myRenderer;



    void Start ()
    {
        myRenderer = GetComponent<Renderer>();
        rigidBodyHolder = GetComponent<Rigidbody>();
    }


    void FixedUpdate ()
    {
        targetDistance = Vector3.Distance(fpsTarget.position, transform.position); //distance to the target... 
        if (targetDistance < visionDistance)
        {
            myRenderer.material.color = Color.green;
            turnToPlayer();
        }

        if (targetDistance < attackDistance)
        {
            help();
        }
        //visionDistance makes sure that we are close! 

        
        if (targetDistance > 300) 
        { 
            //Destroy object since we are probably in free fall or flying away on the y-axis. 
            Destroy(gameObject);
        }

    } 

    public void turnToPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(fpsTarget.position - transform.position);
        transform.rotation = Quaternion.Slerp( transform.rotation, rotation, Time.deltaTime * damping);
    }
    public void help()
    {
        rigidBodyHolder.AddForce(transform.forward * enemyMovementSpeed);
    }
}