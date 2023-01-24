using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private PlayerManager playerManager;
    private AnimalHunger animalHunger;
    private void Start()
    {
        var player = GameObject.FindWithTag("Player");
        playerManager = player.GetComponent<PlayerManager>();
        animalHunger = gameObject.GetComponent<AnimalHunger>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            //Fed the animal
            gameObject.GetComponent<AnimalHunger>().FeedAnimal();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            //decrease player health
            playerManager.DecreaseLive();
        }
    }
}
