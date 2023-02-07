using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager _gameManager;
    public ParticleSystem explosionParticle;
    
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4.25f;
    private float ySpawnPos = -2;
    public int pointValue;
    
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(),ForceMode.Impulse);
        transform.position = RandomSpawnPos();

        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    
    private void OnMouseDown() 
    {
        if(_gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            _gameManager.UpdateScore(pointValue);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        Destroy(gameObject);

        // if good objects enter into the sensor then stop the game
        if(!gameObject.CompareTag("Bad"))
        {
            _gameManager.GameOver();
        }
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    Vector3 RandomTorque()
    {
        return new Vector3(Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque),
            Random.Range(-maxTorque, maxTorque));
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}