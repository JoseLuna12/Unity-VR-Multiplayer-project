using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiParentController : MonoBehaviour
{
    
    GameObject GrandParent;
    Transform[] Childrens;
    Transform[] allGames;
    Transform gameOnlyComponents;

    Animator uiAnimator;
    private bool isOpenLocal;


    public bool debugChild;

    void Start()
    {
        debugChild = true;
        GrandParent = this.transform.gameObject;

        uiAnimator = GetComponent<Animator>();
        isOpenLocal = false;

        if (debugChild)
            getChildsObject(GrandParent);
    }

    //here i save the child objects of the UI canvas to an array
    private void getChildsObject(GameObject gp)
    {
        //Extract every child in the canvas
        //Every child in the canvas represent every interactable thing in canvas

        int children = gp.transform.childCount;
        Childrens = new Transform[children];

        for (int i = 0; i < children; ++i)
            Childrens[i] = gp.transform.GetChild(i);

        //Extract children from the Game container
        //Game Container contain every miniGame representation in the UI

        int gameCardCount = Childrens[0].transform.childCount;
        allGames = new Transform[gameCardCount];

        for (int h = 0; h < gameCardCount; h++)
            allGames[h] = Childrens[0].transform.GetChild(h);

        debugChild = false;
    }

    public void OpenUi(bool Is)
    {
        uiAnimator.SetBool("isOpen", Is);
    }

    public void sortGames(string gameName, bool active)
    {
        int gameCardCount = Childrens[0].transform.childCount;
        for (int i= 0; i< gameCardCount; ++i)
        {
            if(allGames[i].transform.gameObject.name == gameName)
            {
                Transform onlyGame = allGames[i].transform;
                int children = onlyGame.transform.childCount;
                gameOnlyComponents = onlyGame.transform.GetChild(children);

                gameOnlyComponents.gameObject.SetActive(active);
            }
        }
    }

    public void debugVoid()
    {
        Debug.Log("Here i called from another script");
    }

}
