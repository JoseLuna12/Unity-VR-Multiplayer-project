using Photon.Pun;
using Photon.Realtime;
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

        Debug.Log("Joined Room  " + PhotonNetwork.CurrentRoom.Name);

        if(PhotonNetwork.CurrentRoom.Name == "game1")
        {
            startGame(1);
        }else if(PhotonNetwork.CurrentRoom.Name == "game2"){
            startGame(2);
        }

        
    }

    private void startGame(int level)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("starting Game");
            PhotonNetwork.LoadLevel(level);
        }
    }


}
