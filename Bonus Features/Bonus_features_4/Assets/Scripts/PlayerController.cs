using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public GameObject powerUpIndicator;
    public GameObject rocketPrefab;
    public TextManager TM;
    
    [HideInInspector]
    public int rocketCount;
    
    [SerializeField]
    private float speed; // 5f
    private float powerUpForce = 20f;
    private float smashForce = 100f;
    private float smashingRadius = 15f;
    public float countDown;
    
    public PowerupType currentPowerUpType = PowerupType.None;

    private Coroutine powerUpCoroutine;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed);
        powerUpIndicator.transform.position = transform.position;

        if (Input.GetKeyDown(KeyCode.F) && currentPowerUpType == PowerupType.Rocket && rocketCount > 0)
        {
            LaunchRocket();
            if (--rocketCount == 0)
            {
                StopCoroutine(powerUpCoroutine);
                ResetPowerup();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && currentPowerUpType == PowerupType.Smash)
        {
            StartCoroutine(SmashingRoutine());
        }


        if (Input.GetKeyDown(KeyCode.Q))
        {
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var enemy in enemies)
            {
                Destroy(enemy);
            }
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            if (currentPowerUpType != PowerupType.None)
            {
                ResetPowerup();
                StopCoroutine(powerUpCoroutine);
            }
            powerUpIndicator.SetActive(true);
            currentPowerUpType = other.gameObject.GetComponent<PowerUp>().powerUpType;
            TM.powerUpTimer.enabled = true;
            if (currentPowerUpType == PowerupType.Rocket)
            {
                TM.rocketCount.enabled = true;
                rocketCount = 3;
            }
            powerUpCoroutine = StartCoroutine(PowerupCountdown());
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Enemy") && currentPowerUpType == PowerupType.Pushback)
        {
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 forceDirection = other.transform.position - transform.position;
            enemyRb.AddForce(forceDirection * powerUpForce, ForceMode.Impulse);
        }
    }

    private void Smashing()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Rigidbody enemyRigidbody;
        foreach (var enemy in enemies)
        {
            enemyRigidbody = enemy.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (enemy.transform.position - transform.position).normalized;
            if (awayFromPlayer.magnitude <= smashingRadius)
            {
                float distance = Vector3.Distance(enemy.transform.position, transform.position);
                enemyRigidbody.AddForce(awayFromPlayer.normalized * smashForce / distance , ForceMode.Impulse);
            }
        }
    }
    
    private void LaunchRocket()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            var rocketInstance = Instantiate(rocketPrefab, transform.position + Vector3.up, rocketPrefab.transform.rotation);
            rocketInstance.GetComponent<RocketLaunch>().Fire(enemies[i].transform);
        }
    }

    // Sets power up type to none and disable power up indicator
    private void ResetPowerup()
    {
        currentPowerUpType = PowerupType.None;
        powerUpIndicator.SetActive(false);
        TM.powerUpTimer.enabled = false;
        TM.rocketCount.enabled = false;
    }
    
    IEnumerator SmashingRoutine()
    {
        playerRb.AddForce(Vector3.up * 30f, ForceMode.Impulse);
        yield return new WaitForSeconds(0.25f);
        playerRb.AddForce(Vector3.down * 60f, ForceMode.Impulse);

        yield return new WaitUntil(() => transform.position.y <= 0.25f);
        playerRb.velocity /= 2;
        Smashing();
    }
    
    IEnumerator PowerupCountdown()
    {
        countDown = 7f;
        while (countDown >= 0)
        {
            countDown -= Time.deltaTime;
            yield return null;
        }
        ResetPowerup();
    }
}
