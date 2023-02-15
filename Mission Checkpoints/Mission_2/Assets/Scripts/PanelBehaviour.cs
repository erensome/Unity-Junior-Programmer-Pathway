using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBehaviour : MonoBehaviour
{
    public float speed = 0.4f;

    private Vector3 pointA = new Vector3(9.13f, 9.24f, 3f);

    private Vector3 pointB= new Vector3(9.13f, 9.24f, -3f);

    public float amplitude = 0.5f;
    public float amplitudeOffset = 0.5f;
    
    // Update is called once per frame
    void Update()
    {
        // Use Time.timeSinceLevelLoad for reset the panel position to start position whenever restarting scene.
        // Use Time.time to get randomness for panel position whenever restarting scene.
        float rad = Time.time * speed;
        transform.position = Vector3.Lerp(pointA, pointB, Mathf.Sin(rad) * amplitude + amplitudeOffset);
    }
}
