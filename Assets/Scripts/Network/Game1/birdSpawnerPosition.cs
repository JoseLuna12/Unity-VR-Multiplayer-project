using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdSpawnerPosition : MonoBehaviour
{
    public static birdSpawnerPosition BP;
    public Transform[] spawnPointsBirds;

    private void OnEnable()
    {
        if (birdSpawnerPosition.BP == null)
        {
            birdSpawnerPosition.BP = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
