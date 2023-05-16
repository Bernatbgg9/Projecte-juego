using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaScript : MonoBehaviour
{
    public float Speed;

    private Rigidbody2D RigidBody2D;
    private Vector2 Direction;

    void Start()
    {
        RigidBody2D = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        RigidBody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
