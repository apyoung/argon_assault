using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Player triggered something");

        //start death sequence
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        //disable controls
        print("player is dying");
        SendMessage("OnPlayerDeath");
    }
}
