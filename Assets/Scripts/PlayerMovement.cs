using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float PlayerSpeed = 1.5f;
    private float PlayerRun;
    
    

    public Rigidbody2D Rigidbody;
    private Camera Camera;
    public Animator Animator;
    

    Vector2 movement;

    Vector2 mousePosition;

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

        //mousePosition = Camera.ScreenToWorldPoint(Input.mousePosition);


    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Rigidbody.MovePosition(Rigidbody.position + movement.normalized * PlayerRun * Time.fixedDeltaTime);
        }
        else
        {
            Rigidbody.MovePosition(Rigidbody.position + movement.normalized * PlayerSpeed * Time.fixedDeltaTime);
        }

       

        /*Vector2 direction = mousePosition - Rigidbody.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Rigidbody.rotation = angle; */
    }
}
