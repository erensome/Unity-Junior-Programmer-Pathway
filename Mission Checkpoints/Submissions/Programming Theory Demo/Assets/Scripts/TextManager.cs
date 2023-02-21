using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text usernameText;

    public Text shapeText;
    
    // Start is called before the first frame update
    void Start()
    {
        usernameText.text = MainManager.Instance.playerName;
    }
    
    // Abstraction
    public void UpdateShapeText(string shapeName, Color shapeColor)
    {
        shapeText.text = shapeName;
        shapeText.color = shapeColor;
    }
}
