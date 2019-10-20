using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnFloor : MonoBehaviour
{

    public Rigidbody turtle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.Space))
        {

            // Instantiate the projectile at the position and rotation of this transform
            Rigidbody clone;
            clone = Instantiate(turtle, transform.position, this.transform.rotation);

            // Give the cloned object an initial velocity along the current
            // object's Z axis
            
        }
    }
}
