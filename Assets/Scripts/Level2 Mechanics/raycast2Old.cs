using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast2Old : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            if (active)
            {

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetButtonDown("Fire1"))
                {
                    //shootFunction();

                    grabFunction();

                    //instansiateMechanic();
                    //view.RPC("grabFunction" ,RpcTarget.All, true);
                    //view.RPC("instansiateMechanic", RpcTarget.All);
                    instansiateMechanic();
                    Debug.Log(graved + " el booleano");
                }
                if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) || Input.GetButtonUp("Fire1"))
                {
                    //grabFunction(false);
                    //view.RPC("grabFunction", RpcTarget.All, false);
                }

                if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad) || Input.GetKeyDown("space"))
                {
                    character.transform.position += new Vector3(0, val, 0);
                    if (character.transform.position.y >= 14)
                    {
                        val = -1;
                    }
                    if (character.transform.position.y <= 8)
                    {
                        val = 1;
                    }

                }
            }
        }
    }

    private void grabFunction()
    {
        //Debug.Log("shoot");
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.green);
        if (Physics.Raycast(cannon.transform.position, cannon.transform.forward, out hit))
        {
            if (hit.transform.CompareTag("movible"))
            {
                graved = !graved;
                bool grab = graved;
                if (hit.transform.gameObject.GetComponent<objectMechanics>().recogible)
                {
                    if (grab)
                    {

                        PhotonView pv = hit.transform.GetComponent<PhotonView>();
                        if (pv)
                        {
                            //hit.collider.gameObject.GetComponent<BirdVelocity>().birdDeath();
                            pv.RPC("grabfunc", RpcTarget.All);
                            hit.transform.position = puntero.position;
                            //hit.transform.SetParent(cannon.transform);
                            //ficha = hit.transform.gameObject;
                        }
                        // hit.transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                        // hit.transform.gameObject.GetComponent<Rigidbody>().useGravity = false;
                        // hit.transform.gameObject.GetComponent<objectMechanics>().suelto = false;
                        //hit.transform.gameObject.GetComponent<objectMechanics>().grabfunc();

                    }
                    else if (!grab)
                    {
                        PhotonView pv = hit.transform.GetComponent<PhotonView>();
                        if (pv)
                        {
                            //hit.collider.gameObject.GetComponent<BirdVelocity>().birdDeath();
                            pv.RPC("nograbFunc", RpcTarget.All);
                            hit.transform.position = puntero.TransformPoint(Vector3.zero);
                            //hit.transform.SetParent(null);
                            //ficha.transform.SetParent(null);
                            //ficha = null;
                            Debug.Log("lo soloto");
                            return;
                        }
                        //   hit.transform.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                        //   hit.transform.gameObject.GetComponent<Rigidbody>().useGravity = true;
                        //hit.transform.gameObject.GetComponent<objectMechanics>().nograbFunc();
                        //hit.transform.SetParent(null);
                        //    hit.transform.gameObject.GetComponent<objectMechanics>().resetPositionRotation();
                        //   hit.transform.gameObject.GetComponent<objectMechanics>().suelto = true;

                    }
                }
            }
        }

    }

    //[PunRPC]
    private void instansiateMechanic()
    {

        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.green);
        if (Physics.Raycast(cannon.transform.position, cannon.transform.forward, out hit))
        {
            Debug.Log(hit.transform.tag + " " + hit.transform.name);
            if (hit.transform.CompareTag("spawner"))
            {
                Debug.Log("entre a la funcion si detecta spawner");
                //hit.transform.gameObject.GetComponent<SpawnCube>().callFunctionInstansiate();
                PhotonView pv = hit.transform.GetComponent<PhotonView>();
                if (pv)
                {
                    //hit.collider.gameObject.GetComponent<BirdVelocity>().birdDeath();
                    pv.RPC("instansiateCube", RpcTarget.MasterClient);
                }
            }
        }
    }

    private void shootFunction()
    {
        //Debug.Log("shoot");
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
