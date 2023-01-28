using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;
    [SerializeField] private float leftBound;
    private PlayerController playerController;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the object to the left until the player loses.
        if (!playerController.isGameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    
        // Check for left boundary and be sure the object is an obstacle. (We use "MoveLeft" script for another objects. e.g. "Background")
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
