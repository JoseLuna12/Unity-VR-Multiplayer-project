using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocations : MonoBehaviour
{

    public static PlayerLocations PL;
    public Transform[] spawnPointsPlayer;

    private void OnEnable()
    {
        if (PlayerLocations.PL == null)
        {
            PlayerLocations.PL = this;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
