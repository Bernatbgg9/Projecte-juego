using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator Animator;
    [SerializeField] private ParticleSystem Dust;
    public AudioSource Steps;
    public VectorValue startingPos;
    private SpriteRenderer playerRenderer;

    public float PlayerSpeed = 1.5f;
    private float PlayerRun;
    private Vector2 movement;
    private bool facingRight = true;
    
    private void Start()
    {
        Animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Steps = GetComponent<AudioSource>();
        playerRenderer = GetComponent<SpriteRenderer>();

        AudioManager.PlayRandomMusic();

        if (SceneManager.GetActiveScene().name == "Spawn")
        {
            transform.position = startingPos.spawnValue;
        }

        if (SceneManager.GetActiveScene().name == "FirstRoom")
        {
            transform.position = startingPos.firstRoomValue;
        }
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.sqrMagnitude > 0.1)
        {
            if (!Steps.isPlaying)
            {
                Steps.Play();
            }
        }
        else
        {
          Steps.Stop();
        }

        Animator.SetFloat("Horizontal", movement.x);
        Animator.SetFloat("Vertical", movement.y);
        Animator.SetFloat("Speed", movement.sqrMagnitude);
        PlayerRun = PlayerSpeed + 0.5f;
    }

    private void FixedUpdate()
    {
        if (movement.x > 0 && !facingRight)
        {
            Flip();
        }

        if (movement.x < 0 && facingRight)
        {
            Flip();
        }

        Run();
    }

    private void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.MovePosition(rb.position + movement.normalized* PlayerRun * Time.fixedDeltaTime);
            Dust.Play();
        }
        else
        {
            rb.MovePosition(rb.position + movement.normalized * PlayerSpeed * Time.fixedDeltaTime);
        }
    }

    private void Flip()
    {
        /*Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;*/

        playerRenderer.flipX = facingRight;
        facingRight = !facingRight;
    }
}
