using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickStartRoom : MonoBehaviourPunCallbacks
{
    public override void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    public override void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room");
        startGame();
    }

    private void startGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("starting Game");
            PhotonNetwork.LoadLevel(1);
        }
    }
}
