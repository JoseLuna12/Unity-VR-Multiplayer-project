using Photon.Pun;
using System.IO;
using UnityEngine;
public class SpawnerSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.PlayerList.Length == 2)
        {
            for (int i = 0; i<= 2; i++)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonPlayerPrefabs", "BirdSpawner"), birdSpawnerPosition.BP.spawnPointsBirds[i].position, birdSpawnerPosition.BP.spawnPointsBirds[i].rotation, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
