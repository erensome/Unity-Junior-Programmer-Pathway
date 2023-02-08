using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI livesText;
    public GameObject pausePanel;
    public Slider volumeSlider;
    public Button restartButton;
    public GameObject titleScreen;
    private AudioSource audioSource;
    private int health = 0;
    public float spawnRate = 1f;
    public bool isGameActive;
    public bool isGamePaused = false;
   
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isGameActive)
        {
            TogglePause();
        }
    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0,targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateLives(int lives)
    {
        health += lives;
        livesText.text = $"Lives: {health}";
        if (health == 0)
            GameOver();
    }
    
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = $"Score: {score}";
    }

    public void UpdateVolume()
    {
        audioSource.volume = volumeSlider.value;
    }
    
    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void StartGame(int difficultyLevel)
    {
        spawnRate /= difficultyLevel;
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        UpdateLives(3);
        titleScreen.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void TogglePause()
    {
        // Continue the game
        if (isGamePaused)
        {
            pausePanel.gameObject.SetActive(false);
            Time.timeScale = 1f;
            isGamePaused = false;
        }
        else //Pause the game
        {
            pausePanel.gameObject.SetActive(true);
            Time.timeScale = 0f;
            isGamePaused = true;
        }
    }
}
