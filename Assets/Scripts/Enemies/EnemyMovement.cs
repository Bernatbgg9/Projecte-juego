using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float accelerationTime = 3f;
    public float maxSpeed = 2f;

    public float moveSpeed = 1f;
    Vector2 moveDirection;

    public DetectionZone detectionZone;
    Rigidbody2D rb;
    public Animator Animator;

    void Start()
    {
        Animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            moveDirection = new Vector2(Random.Range(-1.5f, 1.5f), Random.Range(-1.5f, 1.5f));
        }    
    }

    private void Update()
    {
        if (detectionZone.detectedObjs.Count > 0)
        {
            Vector3 direction = (detectionZone.detectedObjs[0].transform.position - transform.position).normalized;
            moveDirection = direction;
        }

        Animator.SetFloat("Horizontal", moveDirection.x);
        Animator.SetFloat("Vertical", moveDirection.y);
        Animator.SetFloat("Speed", moveDirection.sqrMagnitude);

        if (detectionZone.detectedObjs.Count > 0)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }

    /*public float speed;

    public bool esDerecha;

    public float contadorT;
    public float tiempoParaCambiar;

    // Start is called before the first frame update
    void Start()
    {
        contadorT = tiempoParaCambiar;  
    }

    // Update is called once per frame
    void Update()
    {
       if (esDerecha == true)
       {
            transform.position += Vector3.right * speed * Time.deltaTime;
            //transform.localScale = new Vector3(-2, 2, 2);
       }

        if (esDerecha == false)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            //transform.localScale = new Vector3(2, 2, 2);
        }

        contadorT -= Time.deltaTime;

        if (contadorT <= 0)
        {
            contadorT = tiempoParaCambiar;
           // transform.localScale = new Vector3(1.0f * -1, 1.0f, 1.0f);
            esDerecha = !esDerecha;
        }
    }*/
}
