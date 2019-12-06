using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using Photon.Realtime;
using UnityEngine.UI;

public class NetworkShoot : MonoBehaviour
{
    public GameObject cannon;
    public Text marcador;
    public int marcadorInt = 0;
    PhotonView view;
    public GameObject winSpace;
    // Start is called before the first frame update
    void Start()
    {
        winSpace = GameObject.Find("placeWin");
        marcador.text = marcadorInt.ToString(); 
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            if (Input.GetButtonDown("Fire1") || OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
            {
                //GameObject Go = PhotonNetwork.Instantiate(Path.Combine("PhotonPlayerPrefabs", bullet.name), 
                //                transform.FindChild("yay").transform.position, 
                //                Quaternion.identity, 0);

                //Rigidbody GoR = Go.GetComponent<Rigidbody>();
                //GoR.velocity = transform.TransformDirection(Vector3.forward * 100);
                //PhotonNetwork.Instantiate(Path.Combine("PhotonPlayerPrefabs", bullet.name), cannon.transform.position, Quaternion.identity);
                //shootFunction();
                view.RPC("shootFunction", RpcTarget.All);
            }
        }
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.green);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");

            Debug.Log(hit.transform.name);
        }
        marcador.text = marcadorInt.ToString();
    }

    [PunRPC]
    private void shootFunction()
    {
        Debug.Log("shoot");
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.green);
        if (Physics.Raycast(cannon.transform.position, cannon.transform.forward, out hit))
        {
            if (hit.transform.CompareTag("pajaro"))
            {
                PhotonView pv = hit.transform.GetComponent<PhotonView>();
                if (pv)
                {
                    //hit.collider.gameObject.GetComponent<BirdVelocity>().birdDeath();
                    pv.RPC("birdDeath", RpcTarget.All);
                    //pv.RPC("deathBird", RpcTarget.All);
                    view.RPC("sumaMarcador", RpcTarget.All);
                }
            }
        }
    }

    [PunRPC]
    private void sumaMarcador()
    {
        marcadorInt++;
        if (marcadorInt >= 10)
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPlayerPrefabs", "End"), winSpace.transform.position, winSpace.transform.rotation);
        }
    }
}
