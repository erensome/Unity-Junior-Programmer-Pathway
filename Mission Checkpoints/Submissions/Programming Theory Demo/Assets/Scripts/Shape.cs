using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shape : MonoBehaviour
{
    // Encapsulation
    public string ShapeName { get; set; }
    public Color ShapeColor { get; set; }

    protected TextManager TextManager;
    
    // Start is called before the first frame update
    void Start()
    {
        TextManager = GameObject.Find("Text Manager").GetComponent<TextManager>();
        SetInfo();
    }

    private void OnMouseDown()
    {
        DisplayText();
    }

    protected abstract void SetInfo();
    protected abstract void DisplayText();

}
