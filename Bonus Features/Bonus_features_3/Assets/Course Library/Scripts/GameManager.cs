using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private SpawnManager spawnManager;
    private GameObject player;
    private PlayerController playerController;
    private Animator playerAnimator;
    private MoveLeft backgroundMoveLeft;
    private AudioSource cameraAudioSource;
    private bool isGameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        playerAnimator = player.GetComponent<Animator>();
        cameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        backgroundMoveLeft = GameObject.Find("Background").GetComponent<MoveLeft>();

        playerAnimator.speed = .7f;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x < 0)
        {
            player.transform.position = new Vector3(Mathf.Lerp(-3,0,Time.time),0,0);
        }
        else if(player.transform.position.x == 0 && !isGameStarted)
        {
            StartGame();
            isGameStarted = true;
        }
    }

    void StartGame()
    {
        spawnManager.enabled = true;
        playerController.enabled = true;
        backgroundMoveLeft.enabled = true;
        cameraAudioSource.Play();
        playerAnimator.speed = 1.5f;
    }
}
