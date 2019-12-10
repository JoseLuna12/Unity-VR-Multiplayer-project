using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quickStartLobby : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update

    public bool room1, room2;
    TypedLobby GetTyped;

    void Start()
    {
        GetTyped = PhotonNetwork.CurrentLobby;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        //quickStartButton.SetActive(true);
        Debug.Log("Conectado");

    }


    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        

        base.OnJoinRoomFailed(returnCode, message);
        //createRoom("game1");
        //createRoom("game2");
        //PhotonNetwork.CreateRoom("protoroom1", new RoomOptions { MaxPlayers = 5 });
    }

    public void createRoom(string rn)
    {
        if (rn != null)
        {
            Debug.Log("Creating room "+ rn);
            RoomOptions roomOps2 = new RoomOptions() { IsVisible = true, IsOpen = true };
            PhotonNetwork.CreateRoom(rn, roomOps2);
            Debug.Log(rn+" creado");
            return;
        }
        Debug.Log("Creating room");
        int randomRoomNumber = Random.Range(0, 1000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true};
        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOps);
        Debug.Log("Room" + randomRoomNumber);

    }


    public void QuickStart()
    {
        //quickStartButton.SetActive(false);
        //quickCancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
        Debug.Log("Quick Start");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        Debug.LogError("Cant join room " + message);
        createRoom(null);
    }





    public void joinGame1Start()
    {
        //createRoom("game1");
        RoomOptions roomOps2 = new RoomOptions() { IsVisible = true, IsOpen = true };

        PhotonNetwork.JoinOrCreateRoom("game1", roomOps2, GetTyped);

       // PhotonNetwork.JoinRoom("game1");
        Debug.Log("intentando entrar game1");
    }


    public void joinGame2Start()
    {
        //createRoom("game2");
        //PhotonNetwork.JoinRoom("game2");
        RoomOptions roomOps2 = new RoomOptions() { IsVisible = true, IsOpen = true };

        PhotonNetwork.JoinOrCreateRoom("game2", roomOps2, GetTyped);
        Debug.Log("intentando entrar game2");
    }




}
