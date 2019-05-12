using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float targetDistance = 10;
    public float visionDistance = 9;
    public float attackDistance = 10;
    public float enemyMovementSpeed = 5;
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
            myRenderer.material.color = Color.blue;
            turnToPlayer();
        }
        if (targetDistance < attackDistance)
        {
            attack();
        }
        //visionDistance makes sure that we are close! 

        
        if (targetDistance > 500) 
        { 
            //Destroy object since we are probably in free fall. 
            Destroy(gameObject);
        }

    } 

    public void turnToPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(fpsTarget.position - transform.position);
        transform.rotation = Quaternion.Slerp( transform.rotation, rotation, Time.deltaTime * damping);
    }
    public void attack()
    {
        rigidBodyHolder.AddForce(transform.forward * enemyMovementSpeed);
    }
}