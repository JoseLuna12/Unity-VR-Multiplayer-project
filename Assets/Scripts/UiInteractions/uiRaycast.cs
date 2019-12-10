using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uiRaycast : MonoBehaviour
{

    bool uiPlayingSound;
    public AudioSource uiAudioSource;
    public GameObject loadSceneManager;
    
    // Start is called before the first frame update
    void Start()
    {

        uiPlayingSound = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.green);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {

            if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) || Input.GetMouseButtonDown(0))
            {
                if (hit.collider.gameObject.tag == "ui")
                    interactableUi(hit.collider.gameObject);
            }
        }

        if (Input.GetMouseButton(0))
        {
            
        }

    }

    public void interactableUi(GameObject Iui)
    {
        uiPlayingSound = false;

        if (!uiAudioSource.isPlaying && !uiPlayingSound)
        {
            uiAudioSource.Play();
            uiPlayingSound = true;
        }
        else
        {
            uiPlayingSound = false;
            uiAudioSource.Stop();            
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



        if(Iui.transform.name == "CardWhite")
        {
            GameObject GameParent;
            Transform gameChildren;
            int childrenCount;
            GameParent = Iui.transform.parent.gameObject;
            childrenCount = gameObject.transform.childCount;
            gameChildren = GameParent.transform.GetChild(childrenCount);
            gameChildren.transform.gameObject.SetActive(true);
            //SceneManager.LoadScene("birdLevel");
            //loadSceneManager.transform.GetComponent<joinGameRoom1>();
            loadSceneManager.transform.gameObject.GetComponent<quickStartLobby>().joinGame1Start();
        }

        if (Iui.transform.name == "game2")
        {
            GameObject GameParent;
            Transform gameChildren;
            int childrenCount;
            GameParent = Iui.transform.parent.gameObject;
            childrenCount = gameObject.transform.childCount;
            gameChildren = GameParent.transform.GetChild(childrenCount);
            gameChildren.transform.gameObject.SetActive(true);
            //SceneManager.LoadScene("birdLevel");
            //loadSceneManager.transform.GetComponent<joinGameRoom1>();
            loadSceneManager.transform.gameObject.GetComponent<quickStartLobby>().joinGame2Start();
        }

        if (Iui.transform.name == "menu")
        {
            GameObject GameParent;
            Transform gameChildren;
            int childrenCount;
            GameParent = Iui.transform.parent.gameObject;
            childrenCount = gameObject.transform.childCount;
            gameChildren = GameParent.transform.GetChild(childrenCount);
            gameChildren.transform.gameObject.SetActive(true);
            SceneManager.LoadScene("Index");
        }


    }
    
}
