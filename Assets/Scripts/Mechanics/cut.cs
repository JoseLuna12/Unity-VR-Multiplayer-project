using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cut : MonoBehaviour
{
    public Rigidbody bala;

    public float fireRate = 3f;

    private float nextFire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Ray ray = this.gameObject;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");

            if(hit.collider.gameObject.tag == "pajaro" && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                hit.collider.gameObject.GetComponent<BirdVelocity>().birdDeath();
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            //Debug.Log("Did not Hit");
        }


        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody clone;
            clone = Instantiate(bala, transform.position, this.transform.rotation);

            // Give the cloned object an initial velocity along the current
            // object's Z axis
            clone.velocity = transform.TransformDirection(Vector3.forward * 300);
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        CubeCut.Cut(collision.transform, transform.position);
    }



}
