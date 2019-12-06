using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Chat;
using System.IO;


public class InstantsiateBird : MonoBehaviour
{
    public Rigidbody projectile;
    public int velocity;
    PhotonView pv;

    private void Start()
    {
        pv = GetComponent<PhotonView>();
        StartCoroutine(selectInstansiator(1));
    }

    void Update()
    {
        // Ctrl was pressed, launch a projectile
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Instantiate the projectile at the position and rotation of this transform
            Rigidbody clone;
            clone = Instantiate(projectile, transform.position, this.transform.rotation);

            // Give the cloned object an initial velocity along the current
            // object's Z axis
            clone.velocity = transform.TransformDirection(Vector3.forward * velocity);
            //Destroy(clone, 5);
        }
    }

    [PunRPC]
    public void instansiateBirdPlease()
    {
        //Rigidbody clone;
        //clone = Instantiate(projectile, transform.position, this.transform.rotation);

        PhotonNetwork.Instantiate(Path.Combine("PhotonPlayerPrefabs", "birdProp"), this.transform.position, this.transform.rotation);

        

        // Give the cloned object an initial velocity along the current
        // object's Z axis
        //clone.velocity = transform.TransformDirection(Vector3.forward * velocity);
    }

    [PunRPC]
    public IEnumerator selectInstansiator(float velSpawn)
    {

        yield return new WaitForSeconds(velSpawn);
        float ran = Random.Range(1f, 2.6f);
        pv.RPC("instansiateBirdPlease", RpcTarget.All);
        //instansiateBirdPlease();
        StartCoroutine(selectInstansiator(ran));
    }

}
