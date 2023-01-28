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
    private float jumpForce = 100f;
    [SerializeField]
    private float gravityModifier;
    private float score = 0f;
    private float scoreFactor = 1f;
    
    private bool isOnGround = true;
    private bool doubleJump = true;
    public bool isGameOver = false;

    
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    
    // We need a Coroutine object to start and stop IEnumerator. (We should use same object to stop a coroutine, Otherwise it won't stop and invoke infinitely)
    private Coroutine PrintScoreCoroutine;

    // MoveLeft ref to adjust background speed.
    private MoveLeft backgroundMoveLeft;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerAudioSource = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
        PrintScoreCoroutine = StartCoroutine(PrintScore());
        backgroundMoveLeft = GameObject.Find("Background").GetComponent<MoveLeft>();
    }

    // Update is called once per frame
    void Update()
    {
        // Jump ability
        JumpAbility();
        
        // Dash ability
        DashAbility();
        
        //Increase score each frame and multiply by scoreFactor.
        score += Time.deltaTime * scoreFactor;
    }

    private IEnumerator PrintScore()
    {
        while (true)
        {
            Debug.Log((int)score);
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // A glitch occurs when the player died top of the obstacle therefore I add isGameOver states.
        if (other.gameObject.CompareTag("Ground") && !isGameOver)
        {
            isOnGround = true;
            doubleJump = true;
            dirtParticle.Play();
        }
        else if (other.gameObject.CompareTag("Obstacle") && !isGameOver)
        {
            isGameOver = true;
            playerAnimator.SetBool("Death_b",true);
            playerAnimator.SetInteger("DeathType_int",1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudioSource.PlayOneShot(crashSound, 1f);
            StopCoroutine(PrintScoreCoroutine);
            Debug.Log("Game Over!");
            Debug.Log("Your score is:  " + (int)score);
        }
    }

    private void JumpAbility()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (isOnGround || doubleJump) && !isGameOver)
        {
            doubleJump = isOnGround ? true : false;
            float newJumpForce = isOnGround ? jumpForce : jumpForce / 2;
            playerRb.AddForce(Vector3.up * newJumpForce,ForceMode.Impulse);
            isOnGround = false;
            playerAnimator.SetTrigger("Jump_trig");
            playerAudioSource.PlayOneShot(jumpSound, 1f);
            dirtParticle.Stop();
        }
    }
    
    private void DashAbility()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerAnimator.speed = 3f;
            scoreFactor = 2f;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            backgroundMoveLeft.speed *= 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerAnimator.speed = 1.5f;
            scoreFactor = 1f;
            backgroundMoveLeft.speed /= 2;
        }
    }
}
