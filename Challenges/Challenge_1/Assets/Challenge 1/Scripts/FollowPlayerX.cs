using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    private Vector3 offset = new Vector3(30f,1.5f,10f);

    // Start is called before the first frame update
    void Start()
    {

    }

    // LateUpdate is called after Update method
    void LateUpdate()
    {
        transform.position = plane.transform.position + offset;
    }
}
