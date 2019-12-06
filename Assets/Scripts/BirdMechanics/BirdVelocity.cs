using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
public class BirdVelocity : MonoBehaviour
{
    // Instantiate a rigidbody then set the velocity
    Rigidbody cloneVel;
    GameObject este;

    //public GameObject particle;

    GameObject puntajeManager;

    PhotonView pv;

    private void Start()
    {
        cloneVel = GetComponent<Rigidbody>();
        //puntajeManager = GameObject.Find("PuntajeManagerP1");
        cloneVel.velocity = transform.TransformDirection(Vector3.forward * 35);
    }

    void Update()
    {
        
        
        
    }

    [PunRPC]
    public void birdDeath()
    {
        //Puntaje();

        Debug.Log("dado");
        PhotonNetwork.Instantiate(Path.Combine("PhotonPlayerPrefabs", "puff"), this.transform.position, this.transform.rotation);
        
        //GameObject ParticleClon;
        //ParticleClon = Instantiate(particle, transform.position, this.transform.rotation);
        this.gameObject.SetActive(false);

    }

    public void Puntaje()
    {
        puntajeManager.gameObject.GetComponent<PuntajeManager>().actualizarMarcadorPlayer();
        Debug.Log("hey");
    }

    private void OnCollisionEnter(Collision collision)
    {
       
       
    }
}
