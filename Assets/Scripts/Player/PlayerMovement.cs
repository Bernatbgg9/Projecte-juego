using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator Animator;
    [SerializeField] private ParticleSystem Dust;
    public AudioSource Steps;
    public VectorValue startingPos;

    public float PlayerSpeed = 1.5f;
    private float PlayerRun;
    private Vector2 movement;
    internal int moveInput;
    

    private void Start()
    {
        Animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Steps = GetComponent<AudioSource>();

        AudioManager.PlayRandomMusic();

        transform.position = startingPos.initialValue;
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
}
