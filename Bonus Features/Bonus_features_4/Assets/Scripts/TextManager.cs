using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text powerUpType;

    public Text powerUpTimer;

    public Text RocketCount;
    
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        print(playerController);
    }

    // Update is called once per frame
    void Update()
    {
        powerUpType.text = playerController.currentPowerUpType.ToString();

        if (playerController.currentPowerUpType == PowerupType.None)
        {
            powerUpTimer.enabled = false;
        }
        else if (playerController.currentPowerUpType == PowerupType.Rocket)
        {
            powerUpTimer.enabled = true;
            powerUpTimer.text = playerController.rocketCount.ToString();
        }
        else
        {
            // Show time
        }
    }
}
