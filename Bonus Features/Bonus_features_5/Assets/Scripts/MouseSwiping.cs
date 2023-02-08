using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSwiping : MonoBehaviour
{
    private Collider col;

    private TrailRenderer trailRenderer;

    private bool swiping = false;

    public GameManager gameManager;
    
    private void Start()
    {
        col = GetComponent<Collider>();
        trailRenderer = GetComponent<TrailRenderer>();
        trailRenderer.enabled = false;
        col.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                swiping = true;
                ToggleComponents();
            }
            if (Input.GetMouseButtonUp(0))
            {
                swiping = false;
                ToggleComponents();
            }
            if (swiping)
            {
                UpdateTrailPosition();
            }
        }
    }


    void UpdateTrailPosition()
    {
        Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MousePos.z = Camera.main.nearClipPlane;
        transform.position = MousePos;
    }

    private void ToggleComponents()
    {
        trailRenderer.enabled = swiping;
        col.enabled = swiping;
    }
}
