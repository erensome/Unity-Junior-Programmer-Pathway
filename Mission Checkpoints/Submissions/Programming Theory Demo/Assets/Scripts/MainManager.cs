using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public string playerName;

    [SerializeField]
    private InputField playerNameTextBox;
    
    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(Instance);
    }
    public void StartGame()
    {
        // 
        playerName = playerNameTextBox.text;
        if (playerName != "")
        {
            //Start game
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.LogError("Please enter a name!");
        }
    }
}
