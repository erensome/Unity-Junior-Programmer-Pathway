using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    private Vector3 cameraOffset = new Vector3(0f, -5f, 8f);
    private Vector3 firstPersonOffset = new Vector3(0f, 1.9f, 1f);
    private bool cameraToggle = false;
    
    [SerializeField]
    private bool isPlayerOne = true;
    
    // Update is called once per frame
    private void Update()
    {
        // Press space to toggle between cameras for Player1
        if(Input.GetKeyDown(KeyCode.Space) && isPlayerOne) cameraToggle = cameraToggle == false ? true : false;
        // Press "C" to toggle between cameras for Player2
        else if (Input.GetKeyDown(KeyCode.C) && !isPlayerOne) cameraToggle = cameraToggle == false ? true : false;
    }
    
    //LateUpdate is called after Update method 
    void LateUpdate()
    {
        // Sets camera position to player position - offset value
        if (cameraToggle)
        {
            transform.position = player.transform.position + firstPersonOffset;
            transform.eulerAngles = player.transform.rotation.eulerAngles;
        }
        else
        {
            transform.position = player.transform.position - cameraOffset;
            transform.eulerAngles = new Vector3(11.153f, 0f, 0f);
        }

    }
}
