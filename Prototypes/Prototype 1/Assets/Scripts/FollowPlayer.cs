using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    private Vector3 cameraOffset = new Vector3(0f, -5f, 8f);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // LateUpdate is called after Update() method.
    void LateUpdate()
    {
        // Sets camera position to player position - offset value
        transform.position = player.transform.position - cameraOffset;
    }
}
