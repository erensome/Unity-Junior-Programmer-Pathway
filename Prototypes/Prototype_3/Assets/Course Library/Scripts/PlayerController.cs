using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnimator;
    private AudioSource playerAudioSource;

    [SerializeField]
    private float jumpForce = 10f;
    [SerializeField]
    private float gravityModifier;
    [SerializeField]
    private bool isOnGround = true;
    public bool isGameOver = false;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    enum ForceType
    {
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerAudioSource = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            isOnGround = false;
            playerAnimator.SetTrigger("Jump_trig");
            playerAudioSource.PlayOneShot(jumpSound, 1f);
            dirtParticle.Stop();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // A glitch occurs when the player died top of the obstacle therefore I added isGameOver state too.
        if (other.gameObject.CompareTag("Ground") && !isGameOver)
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            playerAnimator.SetBool("Death_b",true);
            playerAnimator.SetInteger("DeathType_int",1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudioSource.PlayOneShot(crashSound, 1f);
            Debug.Log("Game Over!");
        }
    }
}
