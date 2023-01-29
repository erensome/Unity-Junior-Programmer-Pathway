using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public GameObject powerUpIndicator;
    [SerializeField]
    private float speed;
    private float powerUpForce = 15f;
    public bool hasPowerup;
    
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
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(powerUpCountdown());
            powerUpIndicator.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 forceDirection = other.transform.position - transform.position;
            enemyRb.AddForce(forceDirection * powerUpForce, ForceMode.Impulse);
        }
    }

    IEnumerator powerUpCountdown()
    {
       yield return new WaitForSeconds(8.0f);
       hasPowerup = false;
       powerUpIndicator.SetActive(false);
       print(hasPowerup);
    }
}
