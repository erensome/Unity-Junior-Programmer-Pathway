using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalHunger : MonoBehaviour
{
    [SerializeField]
    private Image hungerFillImage;
    [SerializeField]
    private int amountToBeFed;
    private int currentFedAmmount = 0;

    private PlayerManager playerManager;
    
    private void Start()
    {
        playerManager = GameObject.FindWithTag("Player").GetComponent<PlayerManager>();
    }

    public void FeedAnimal()
    {
        currentFedAmmount++;
        hungerFillImage.fillAmount = (float) currentFedAmmount / amountToBeFed;

        if (currentFedAmmount >= amountToBeFed)
        {
            playerManager.IncreaseScore(amountToBeFed);
            Destroy(gameObject,0.1f);
        }
        
    }
}
