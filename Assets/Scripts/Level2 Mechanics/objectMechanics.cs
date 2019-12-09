using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectMechanics : MonoBehaviour
{
    // Start is called before the first frame update
    public bool debugTry;
    public float rotationZ;
    void Start()
    {
        debugTry = false;
        rotationZ = this.transform.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void resetPositionRotation()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -30.851f);
        this.transform.eulerAngles = new Vector3(0, 0, this.transform.eulerAngles.z);
        //this.transform.rotation = Quaternion.Euler( new Vector3(0, 0, this.transform.rotation.z));
    }

}
