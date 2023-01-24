using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private PlayerManager playerManager;

    private void Start()
    {
        var player = GameObject.FindWithTag("Player");
        playerManager = player.GetComponent<PlayerManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary"))
        {
            //decrease player health
            if (gameObject.CompareTag("Animal"))
            {
                playerManager.DecreaseLive();
            }
            Destroy(gameObject);
        }
    }
}
