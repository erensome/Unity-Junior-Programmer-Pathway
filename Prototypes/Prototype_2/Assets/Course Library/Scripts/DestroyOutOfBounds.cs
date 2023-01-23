using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float upperBound = 30f;

    private float lowerBound = -7f;
    
    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > upperBound)
        {
            // If we pass "this" keyword into the destroy method. It'll destroy script itself.
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
            Debug.Log("Game Over");
        }
    }
}
