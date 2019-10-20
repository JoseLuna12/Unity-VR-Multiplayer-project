using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantsiateBird : MonoBehaviour
{
    public Rigidbody projectile;

    void Update()
    {
        // Ctrl was pressed, launch a projectile
        if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.Space))
        {
            // Instantiate the projectile at the position and rotation of this transform
            Rigidbody clone;
            clone = Instantiate(projectile, transform.position, this.transform.rotation);

            // Give the cloned object an initial velocity along the current
            // object's Z axis
            //clone.velocity = transform.TransformDirection(Vector3.forward * 25);
            //Destroy(clone, 5);
        }
    }
}
