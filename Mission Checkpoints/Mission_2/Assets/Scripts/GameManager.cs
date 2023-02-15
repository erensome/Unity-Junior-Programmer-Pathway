using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject basketball;
    public PanelBehaviour panelBehaviour; 
    private BallBehaviour ballBehaviour;
    private GameObject mainBall;
    private Rigidbody ballRb;
    private Collider ballCol;
    private Vector3 tossOrigin = new Vector3(18f, 2.5f, 0f);
    private Vector3 forceVector = new Vector3(12f,8f,0f);

    [HideInInspector]
    public float counter;
    private float timer;
    private bool isGameActive = true;

    // UI elements
    public Button restartButton;
    public Text counterText;
    public Text timerText;
    
    // Start is called before the first frame update
    void Start()
    {
        counter = 0f;
        timer = 60f;
        CreateNewBall();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimerText();
        if (Input.GetKeyDown(KeyCode.Space) && ballBehaviour.isActive && isGameActive)
        {
            ProjectileBall();
        }
    }
    
    public void UpdateCounter(int count)
    {
        counter += count;
        counterText.text = $"Count: {counter}";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    void GameOver()
    {
        isGameActive = false;
        panelBehaviour.enabled = false;
        restartButton.gameObject.SetActive(true);
    }

    void UpdateTimerText()
    {
        if (timer > 0)
        {   
            timer -= Time.deltaTime;
            timerText.text = $"Timer: {Mathf.RoundToInt(timer)}";
        }
        else
        {
            GameOver();
        }
    }
    
    void ProjectileBall()
    {
        ballRb.useGravity = true;
        ballRb.AddRelativeForce(forceVector,ForceMode.Impulse);
        ballBehaviour.isActive = false;
        ballCol.enabled = true;
        Invoke("CreateNewBall",0.7f);
    }
    
    void CreateNewBall()
    {
        mainBall = Instantiate(basketball, tossOrigin, basketball.transform.rotation);
        ballRb = mainBall.GetComponent<Rigidbody>();
        ballBehaviour = mainBall.GetComponent<BallBehaviour>();
        ballCol = mainBall.GetComponent<SphereCollider>();
    }
}
