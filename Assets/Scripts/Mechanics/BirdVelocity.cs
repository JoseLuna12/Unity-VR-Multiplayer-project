using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdVelocity : MonoBehaviour
{
    // Instantiate a rigidbody then set the velocity
    Rigidbody cloneVel;
    GameObject este;
    private void Start()
    {
        cloneVel = GetComponent<Rigidbody>();
        cloneVel.velocity = transform.TransformDirection(Vector3.forward * 20);
        
    }

    void Update()
    {
        //cloneVel.velocity = transform.TransformDirection(Vector3.forward * 10);
    }


    public void birdDeath()
    {
        Debug.Log("dado");
        cloneVel.velocity = transform.TransformDirection(-Vector3.up * 5);

    }

    private void OnCollisionEnter(Collision collision)
    {
       
       
    }
}
