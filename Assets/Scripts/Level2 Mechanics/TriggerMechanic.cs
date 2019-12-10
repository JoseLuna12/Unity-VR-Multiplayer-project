using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class TriggerMechanic : MonoBehaviour
{
    // Start is called before the first frame update
    int tiempo = 0;
    public Text timeText;
    PhotonView view;

    void Start()
    {
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = tiempo.ToString();
        if(tiempo > 5)
        {
            
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (    other.transform.CompareTag("movible") || other.transform.CompareTag("tetris")   )
        {
            if(other.transform.GetComponentInParent<objectMechanics>().suelto == true)
            {
                StartCoroutine(ExampleCoroutine(true));
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        
        StartCoroutine(ExampleCoroutine(false));
        StopCoroutine(ExampleCoroutine(false));
        StopAllCoroutines();
        view.RPC("resetearEste", RpcTarget.All);
        //tiempo = 0;
    }

    IEnumerator ExampleCoroutine(bool contar)
    {
        if (contar)
        {
            yield return new WaitForSeconds(1);
            //Debug.Log(tiempo++);
            view.RPC("sumareste", RpcTarget.All);
            StartCoroutine(ExampleCoroutine(contar));
        }
        else
        {
            yield break;
        }
    }

    [PunRPC]
    public void sumareste()
    {
        tiempo++;
    }

    [PunRPC]
    public void resetearEste()
    {
        tiempo = 0;
    }

}
