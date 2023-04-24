using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;

    public Rigidbody2D Rigidbody;
    public Camera Camera;

    Vector2 movement;
    Vector2 mousePosition;
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePosition = Camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        Rigidbody.MovePosition(Rigidbody.position +  movement * Speed * Time.fixedDeltaTime);

        /*Vector2 direction = mousePosition - Rigidbody.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Rigidbody.rotation = angle; */
    }
}
