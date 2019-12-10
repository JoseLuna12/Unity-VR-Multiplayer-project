using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class objectMechanics : MonoBehaviour
{
    // Start is called before the first frame update
    public bool debugTry;
    public float rotationZ;
    public bool suelto;
    public bool recogible;
    public int recogibleDosVeces;

    PhotonView view;
    void Start()
    {
        view = GetComponent<PhotonView>();
        recogibleDosVeces = 0;
        recogible = true;
        suelto = true;
        debugTry = false;
        rotationZ = this.transform.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
    }

    [PunRPC]
    public void resetPositionRotation()
    {
        recogibleDosVeces++;
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -30.851f);
        this.transform.eulerAngles = new Vector3(0, 0, this.transform.eulerAngles.z);
        if(recogibleDosVeces>=2)
            recogible = false;
        //this.transform.rotation = Quaternion.Euler( new Vector3(0, 0, this.transform.rotation.z));
    }

    [PunRPC]
    public void grabfunc()
    {
        this.transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        this.transform.gameObject.GetComponent<Rigidbody>().useGravity = false;
        suelto = false;
    }

    [PunRPC]
    public void nograbFunc()
    {
        this.transform.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        this.transform.gameObject.GetComponent<Rigidbody>().useGravity = true;

        view.RPC("resetPositionRotation", RpcTarget.All);
        suelto = true;
    }

}
