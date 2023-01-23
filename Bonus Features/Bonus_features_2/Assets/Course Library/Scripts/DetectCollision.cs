using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            //increase player score
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            //decrease player health
            
        }
    }
}
