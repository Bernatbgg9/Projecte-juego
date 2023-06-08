using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    enum EState
    {
        Patrol,
        Follow,
        Attack
    }

    FSM<EState> brain;
    Vector3 direction;
    Transform player;
    public DetectionZone detectionZone;
    Animator Animator;
    Rigidbody2D rb;

    public float moveSpeed;
    public float currentTime;
    public Transform[] patrolPoints;
    int currentPointIndex;
    bool once;

    private void Start()
    {
        InitFSM();

        player = GameObject.FindGameObjectWithTag("Player").transform;

        Animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();
    }

    private void InitFSM()
    {
        brain = new FSM<EState>(EState.Patrol);

        brain.SetOnStay(EState.Patrol, PatrolUpdate);
        brain.SetOnStay(EState.Follow, FollowUpdate);
        brain.SetOnStay(EState.Attack, AttackUpdate);

        brain.SetOnExit(EState.Follow, () =>
        {
            Animator.SetFloat("Horizontal", 0);
            Animator.SetFloat("Vertical", 0);
            Animator.SetFloat("Speed", 0);
        });
    }

    private void Update()
    {
        brain.Update();
    }

    void PatrolUpdate()
    {
        Vector3 moveDirection = patrolPoints[currentPointIndex].position - transform.position;
        direction = moveDirection;

        Animator.SetFloat("Horizontal", direction.x);
        Animator.SetFloat("Vertical", direction.y);
        Animator.SetFloat("Speed", direction.sqrMagnitude);

        if (detectionZone.detectedObjs.Count > 0)
        {
            brain.ChangeState(EState.Follow);
        }

        if (transform.position != patrolPoints[currentPointIndex].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, moveSpeed * Time.deltaTime);
        }

        else
        {
            if (once == false)
            {
                once = true;
                StartCoroutine(Wait());
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(currentTime);
        if (currentPointIndex + 1 < patrolPoints.Length)
        {
            currentPointIndex++;
        }

        else
        {
            currentPointIndex = 0;
        }
        once = false;
    }

    void FollowUpdate()
    {
        Vector3 moveDirection = (player.transform.position - transform.position).normalized;
        direction = moveDirection;

        Animator.SetFloat("Horizontal", direction.x);
        Animator.SetFloat("Vertical", direction.y);
        Animator.SetFloat("Speed", direction.sqrMagnitude);

        if (detectionZone.detectedObjs.Count > 0)
        {
            rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;

            if (Vector3.Distance(player.position, transform.position) <= 0.3)
            {
                brain.ChangeState(EState.Attack);
            }
        }

        else
        {
            brain.ChangeState(EState.Patrol);
        }
    }

    void AttackUpdate()
    {
        StartCoroutine(AttackCo());

        if (detectionZone.detectedObjs.Count < 0)
        {
            brain.ChangeState(EState.Patrol);
        }
    }

    IEnumerator AttackCo()
    {
        Animator.SetBool("isAttacking", true);
        yield return new WaitForSeconds(0.5f);
        brain.ChangeState(EState.Patrol);
        Animator.SetBool("isAttacking", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
        }
    }
}
