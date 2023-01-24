using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    
    private Renderer _renderer;
    private Material _material;
    [SerializeField]
    private float rotationSpeed = 10f;

    private Color randomColor;
    private Color lerpedColor;
    
    private int rotationDirection = 1;
    // With A and D keys you can increase/decrease rotation speed of the cube. - Completed
    // With W and S keys you can increase/decrease opacity of the cube. - Completed
    // With Mouse Scroll you can control scale of the cube. - Completed
    // With Space Key you can change rotation direction. - Completed
    // With C key you can change the color randomly. - Completed
    
    // Each time the scene is played cube's color will be randomly selected. - Completed
    // By the time cube's color will change. - Uncompleted
    
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _material = _renderer.material;
        _material.color = GetRandomColor();
    }
    
    void Update()
    {
        transform.Rotate(Mathf.Clamp(rotationSpeed,0f,300f) * Time.deltaTime * rotationDirection, 0.0f, 0.0f);

        if (Input.GetKeyDown(KeyCode.C))
        {
            _material.color = GetRandomColor();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rotationDirection *= -1;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            rotationSpeed -= 20f;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rotationSpeed += 20f;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            var tempColor = _material.color;
            tempColor.a = tempColor.a < 1 ? tempColor.a += .1f : tempColor.a;
            _material.color = tempColor;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            var tempColor = _material.color;
            tempColor.a = tempColor.a > 0 ? tempColor.a -= .1f : tempColor.a;
            _material.color = tempColor;
        }
        if(Input.mouseScrollDelta.y > 0f)
        {
             transform.localScale *= 1.2f;
        }
        if(Input.mouseScrollDelta.y < 0f)
        {
            transform.localScale *= 0.8f;
        }
    }
    
    Color GetRandomColor()
    {
        Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        return color;
    }
}
