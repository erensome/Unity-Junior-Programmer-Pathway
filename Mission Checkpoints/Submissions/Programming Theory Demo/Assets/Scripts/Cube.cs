using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inheritance
public class Cube : Shape
{
    // Polymorphism
    protected override void SetInfo()
    {
        ShapeName = "Cube";
        ShapeColor = Color.blue;
    }
    
    protected override void DisplayText()
    {
        TextManager.UpdateShapeText(ShapeName,ShapeColor);
    }
}
