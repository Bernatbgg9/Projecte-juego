using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr : MonoBehaviour
{

    public float accelerationTime = 3f;
    public float maxSpeed = 2f;
    private Vector2 movement;
    private float timeLeft;

    public float moveSpeed = 1f;
    Vector2 moveDirection;

    public DetectionZone detectionZone;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            movement = new Vector2(Random.Range(-1.5f, 1.5f), Random.Range(-1.5f, 1.5f));
        }
    }

    private void Update()
    {
        if (detectionZone.detectedObjs.Count > 0)
        {
            Vector3 direction = (detectionZone.detectedObjs[0].transform.position - transform.position).normalized;
            moveDirection = direction;
        }

        timeLeft -= Time.fixedDeltaTime;
        if (timeLeft <= 0)
        {
            movement = new Vector2(Random.Range(-1.5f, 1.5f), Random.Range(-1.5f, 1.5f));
            timeLeft += accelerationTime;
        }
    }

    void FixedUpdate()
    {
        if (detectionZone.detectedObjs.Count > 0)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }

        rb.AddForce(movement * maxSpeed);
    }
}
