using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextManager TM;
    public SpawnManager SM;
    public PlayerController PC;
    public bool isGameOver { get; private set; }
    
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
    }

    public void GameOver()
    {
        isGameOver = true;
        SM.enabled = false;
        TM.gameOverObjects.SetActive(true);
        PC.powerUpIndicator.SetActive(false);
        Destroy(PC.gameObject);
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
