using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    int turn;
    GameObject[] players;
    void Start()
    {
        players = new GameObject[2];
    }

    // Update is called once per frame
    void Update()
    {
        switch (turn)
        {
            case 0:
                players[0].transform.GetComponent<RaycastLevel2>().active = true;
                players[1].transform.GetComponent<RaycastLevel2>().active = false;
                break;
            case 1:
                players[0].transform.GetComponent<RaycastLevel2>().active = false;
                players[1].transform.GetComponent<RaycastLevel2>().active = true;
                break;
        }
    }
}
