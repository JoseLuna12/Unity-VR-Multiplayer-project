using Photon.Pun;
using System.IO;
using UnityEngine;
using Photon.Realtime;

public class GameSetup : MonoBehaviour
{
    //[SerializeField] private Texture blue, green;
    GameObject padre;
    GameObject hijo;


    GameObject p1, p2;
    //PhotonView pv;

    void Start()
    {
        createPlayer();
    }

    private void createPlayer()
    {
        if (PhotonNetwork.PlayerList.Length == 1)
        {
            //padre = 
            PhotonNetwork.Instantiate(Path.Combine("PhotonPlayerPrefabs", "OVRCameraRigGreen"), PlayerLocations.PL.spawnPointsPlayer[0].position, PlayerLocations.PL.spawnPointsPlayer[0].rotation, 0);
            //hijo = padre.gameObject.transform.GetChild(0).GetChild(1).GetChild(0).gameObject;
            //hijo.GetComponent<Renderer>().material.color = Color.blue;
            //Debug.Log(hijo.transform.name);
           // p1 = padre.gameObject;
        }

        if (PhotonNetwork.PlayerList.Length == 2)
        {
           // padre = 
            PhotonNetwork.Instantiate(Path.Combine("PhotonPlayerPrefabs", "OVRCameraRigBlue"), PlayerLocations.PL.spawnPointsPlayer[1].position, PlayerLocations.PL.spawnPointsPlayer[1].rotation, 0);           
           // hijo = padre.gameObject.transform.GetChild(0).GetChild(1).GetChild(0).gameObject;
           // hijo.GetComponent<Renderer>().material.color = Color.green;
           // Debug.Log(hijo.transform.name);
            //p2 = padre.gameObject;
        }


        Debug.Log("creating Player");
        //PhotonNetwork.Instantiate(Path.Combine("PhotonPlayerPrefabs", "OVRCameraRig"), Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
