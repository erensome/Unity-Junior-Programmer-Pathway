using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : Shape
{
    protected override void SetInfo()
    {
        ShapeName = "Sphere";
        ShapeColor = Color.green;
    }
    
    protected override void DisplayText()
    {
        TextManager.UpdateShapeText(ShapeName,ShapeColor);
    }
}
