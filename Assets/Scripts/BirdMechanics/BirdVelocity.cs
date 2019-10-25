using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdVelocity : MonoBehaviour
{
    // Instantiate a rigidbody then set the velocity
    Rigidbody cloneVel;
    GameObject este;

    public GameObject particle;

    GameObject puntajeManager;

    private void Start()
    {
        cloneVel = GetComponent<Rigidbody>();
        puntajeManager = GameObject.Find("PuntajeManagerP1");
        
    }

    void Update()
    {
        
        
        //cloneVel.velocity = transform.TransformDirection(Vector3.forward * 10);
    }


    public void birdDeath()
    {
        Puntaje();
        Debug.Log("dado");
        GameObject ParticleClon;
        ParticleClon = Instantiate(particle, transform.position, this.transform.rotation);
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
