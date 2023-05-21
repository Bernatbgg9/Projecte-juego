using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator Animator;
    public float PlayerSpeed = 1.5f;
    private float PlayerRun;
    private Vector2 movement;

    private void Start()
    {
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Animator.SetFloat("Horizontal", movement.x);
        Animator.SetFloat("Vertical", movement.y);
        Animator.SetFloat("Speed", movement.sqrMagnitude);
        PlayerRun = PlayerSpeed + 0.5f;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.MovePosition(rb.position + movement.normalized * PlayerRun * Time.fixedDeltaTime);
        }
        else
        {
            rb.MovePosition(rb.position + movement.normalized * PlayerSpeed * Time.fixedDeltaTime);
        }
    }
}
