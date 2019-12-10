using Photon.Pun;
using System.IO;
using UnityEngine;
using Photon.Realtime;


public class SpawnCube : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] cubos;
    public GameObject SpawnPoint;

    public bool debugTry;

    PhotonView view;
    void Start()
    {
        debugTry = false;
        view = this.transform.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (debugTry)
        {
            //instansiateCube();

            view.RPC("instansiateCube", RpcTarget.All);
            debugTry = !debugTry;
        }
    }



    [PunRPC]
    public void instansiateCube()
    {
        int i = Random.Range(0, 4);
        PhotonNetwork.Instantiate(Path.Combine("PhotonPlayerPrefabs", "Level2", cubos[i].name), SpawnPoint.transform.position, Quaternion.identity, 0);
        //Instantiate(cubos[i], SpawnPoint.transform.position, Quaternion.identity);
        Debug.Log("instansiando pieza");
    }

}
