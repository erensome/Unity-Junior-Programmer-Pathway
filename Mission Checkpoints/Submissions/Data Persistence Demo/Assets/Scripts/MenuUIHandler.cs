using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public InputField userNameTxtBox;
    public Text highScore;
    
    // Start is called before the first frame update
    void Start()
    {
        highScore.text = $"High Score: {DataManager.Instance.GetHighScore()}, {DataManager.Instance.GetHighScoreName()}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void StartGame()
    {
        if (userNameTxtBox.text != "")
        {
            DataManager.Instance.currentUserName = userNameTxtBox.text;
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("Please enter an username");
        }
    }

    public void QuitGame()
    {
#if  UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
