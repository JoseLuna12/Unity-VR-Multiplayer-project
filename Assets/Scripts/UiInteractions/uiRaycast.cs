using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uiRaycast : MonoBehaviour
{

    bool uiPlaySound;
    public AudioSource uiAudioSource;
    
    // Start is called before the first frame update
    void Start()
    {

        uiPlaySound = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.green);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {

            if (hit.collider.gameObject.tag == "ui" && Input.GetMouseButtonDown(0) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                interactableUi(hit.collider.gameObject);
            }
        }


    }

    public void interactableUi(GameObject Iui)
    {
        uiPlaySound = true;

        if (!uiPlaySound || !uiAudioSource.isPlaying)
        {
            uiAudioSource.Play();
            uiPlaySound = false;
        }
        else
        {
            uiAudioSource.Stop();
            uiPlaySound = false;
        }

        GameObject parent;
        parent = Iui.transform.parent.gameObject;
        if(Iui.transform.name == "Open")
        {
            parent.GetComponent<uiParentController>().OpenUi(true);
        }else if(Iui.transform.name == "Close")
        {
            parent.GetComponent<uiParentController>().OpenUi(false);
        }



        if(Iui.transform.name == "Game1")
        {
            GameObject GameParent;
            Transform gameChildren;
            int childrenCount;
            GameParent = Iui.transform.parent.gameObject;
            childrenCount = gameObject.transform.childCount;
            gameChildren = GameParent.transform.GetChild(childrenCount);
            gameChildren.transform.gameObject.SetActive(true);
            SceneManager.LoadScene("BirdLevel");
        }

        uiPlaySound = false;

    }
    
}
