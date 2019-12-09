using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] cubos;
    public GameObject SpawnPoint;

    public bool debugTry;

    void Start()
    {
        debugTry = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (debugTry)
        {
            instansiateCube();
            debugTry = !debugTry;
        }
    }

    public void instansiateCube()
    {
        int i = Random.Range(0, 4);
        Instantiate(cubos[i], SpawnPoint.transform.position, Quaternion.identity);
    }

}
