using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastLevel2 : MonoBehaviour
{
    public GameObject cannon;
    public bool active;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (active) { 

            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                //shootFunction();
                grabFunction(true);
                instansiateMechanic();


            }
            if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
            {
                grabFunction(false);
            }
        }
    }


    private void grabFunction(bool grab)
    {
        Debug.Log("shoot");
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.green);
        if (Physics.Raycast(cannon.transform.position, cannon.transform.forward, out hit))
        {
            if (hit.transform.CompareTag("movible"))
            {
                if (grab)
                {
                    hit.transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    hit.transform.gameObject.GetComponent<Rigidbody>().useGravity = false;
                    
                    hit.transform.SetParent(this.transform);
                }
                else if (!grab)
                {
                    hit.transform.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    hit.transform.gameObject.GetComponent<Rigidbody>().useGravity = true;                    
                    hit.transform.SetParent(null);
                    hit.transform.gameObject.GetComponent<objectMechanics>().resetPositionRotation();
                    return;
                }
            }
        }
        
    }

    private void instansiateMechanic()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.green);
        if (Physics.Raycast(cannon.transform.position, cannon.transform.forward, out hit))
        {
            if (hit.transform.CompareTag("spawner"))
            {
                hit.transform.gameObject.GetComponent<SpawnCube>().instansiateCube();
            }
        }
    }

    private void shootFunction()
    {
        Debug.Log("shoot");
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.green);
        if (Physics.Raycast(cannon.transform.position, cannon.transform.forward, out hit))
        {
            if (hit.transform.CompareTag("movible"))
            {

            }
        }
    }
}
