using UnityEngine;
using System.Collections;

public class Hover : MonoBehaviour
{
    public float hoverForce = 10;

    
    void OnTriggerStay (Collider other)
    {
        other.GetComponent<Rigidbody>().AddForce(transform.up * hoverForce);
    }
}
