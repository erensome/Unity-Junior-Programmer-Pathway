using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : Shape
{
    protected override void SetInfo()
    {
        ShapeName = "Capsule";
        ShapeColor = Color.red;
    }
    
    protected override void DisplayText()
    {
        TextManager.UpdateShapeText(ShapeName,ShapeColor);
    }
}
