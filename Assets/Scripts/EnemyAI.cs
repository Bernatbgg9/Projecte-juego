using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyAI : MonoBehaviour
{
    enum EState
    {
        Idle,
        Wander,
        Follow,
        Attack
    }

    FSM<EState> brain;

    float currentTime;

    Vector3 direction;

    Transform player;

    public DetectionZone detectionZone;

    Animator Animator;

    Rigidbody2D rb;

    public float moveSpeed = 1f;

    private void Start()
    {
        InitFSM();

        currentTime = 0.0f;

        player = GameObject.FindGameObjectWithTag("Player").transform;

        Animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();
    }

    private void InitFSM()
    {
        brain = new FSM<EState>(EState.Idle);

        brain.SetOnEnter(EState.Idle, () => currentTime = 0.0f);

        brain.SetOnEnter(EState.Wander, () =>
        {
            currentTime = 0.0f;
            float randomAngle = Random.Range(0.0f, 360.0f);
            direction = new Vector3(Mathf.Cos(randomAngle), 0.0f, Mathf.Sin(randomAngle));
        });

        brain.SetOnEnter(EState.Follow, () =>
        {

        });

        brain.SetOnStay(EState.Idle, IdleUpdate);
        brain.SetOnStay(EState.Wander, WanderUpdate);
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

    void IdleUpdate()
    {
        if (detectionZone.detectedObjs.Count > 0)
        {
            brain.ChangeState(EState.Follow);
        }

        /*if (Vector3.Distance(player.position, transform.position) < 4.0f)
        {
            brain.ChangeState(EState.Attack);
        }

        currentTime += Time.deltaTime;
        if (currentTime > 2.0f)
        {
            brain.ChangeState(EState.Wander);
        }*/
    }

    void WanderUpdate()
    {
        if (detectionZone.detectedObjs.Count > 0)
        {
            brain.ChangeState(EState.Follow);
        }

        /*transform.position += direction * Time.deltaTime;

        if (Vector3.Distance(player.position, transform.position) < 4.0f)
        {
            brain.ChangeState(EState.Attack);
        }

        currentTime += Time.deltaTime;
        if (currentTime > 4.0f)
        {
            brain.ChangeState(EState.Idle);
        }*/
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
        }

        /*direction = (player.position - transform.position).normalized;
        transform.position += direction * Time.deltaTime;

        if (Vector3.Distance(player.position, transform.position) > 4.0f)
        {
            brain.ChangeState(EState.Idle);
        }*/
    }

    private void AttackUpdate()
    {

    }
}