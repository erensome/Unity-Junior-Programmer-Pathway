using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text powerUpType;

    public Text powerUpTimer;

    public Text rocketCount;

    public Text waveCount;
    
    private PlayerController playerController;

    private SpawnManager spawnManager;
    
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        powerUpType.text = playerController.currentPowerUpType.ToString();
        rocketCount.text =  playerController.rocketCount.ToString();
        powerUpTimer.text = (Mathf.Ceil(playerController.countDown)).ToString();
        waveCount.text = $"Wave: {spawnManager.waveSize}";
    }
}
