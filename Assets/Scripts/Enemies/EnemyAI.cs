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
    Vector3 direction;
    Transform player;
    public DetectionZone detectionZone;
    Animator Animator;
    Rigidbody2D rb;
    public float moveSpeed;
    bool running = false;


    private void Start()
    {
        InitFSM();

        player = GameObject.FindGameObjectWithTag("Player").transform;
        Animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void InitFSM()
    {
        brain = new FSM<EState>(EState.Idle);

        /*brain.SetOnEnter(EState.Wander, () =>
        {
            float randomAngle = Random.Range(0.0f, 360.0f);
            direction = new Vector3(Mathf.Cos(randomAngle), 0.0f, Mathf.Sin(randomAngle));
        });*/

        brain.SetOnStay(EState.Idle, IdleUpdate);
        brain.SetOnStay(EState.Wander, WanderUpdate);
        brain.SetOnStay(EState.Follow, FollowUpdate);
        brain.SetOnStay(EState.Attack, AttackUpdate);

        /*brain.SetOnExit(EState.Follow, () =>
        {
            Animator.SetFloat("Horizontal", 0);
            Animator.SetFloat("Vertical", 0);
            Animator.SetFloat("Speed", 0);
        });*/
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

        else
        {
            brain.ChangeState(EState.Wander);
        }
    }

    void WanderUpdate()
    {
        Animator.SetFloat("Horizontal", direction.x);
        Animator.SetFloat("Vertical", direction.y);
        Animator.SetFloat("Speed", direction.sqrMagnitude);

        if (detectionZone.detectedObjs.Count > 0)
        {
            brain.ChangeState(EState.Follow);
        }

        if (!running)
        {
            StartCoroutine(changeDirection());
        }

        rb.velocity += new Vector2(direction.x, direction.y) * Time.deltaTime;
    }

    IEnumerator changeDirection()
    {
        running = true;
        yield return new WaitForSeconds(2);
        direction.x = Random.Range(-2.0f, 2.0f);
        direction.y = Random.Range(-2.0f, 2.0f);
        running = false;
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
            rb.velocity = new Vector3(direction.x, direction.y) * moveSpeed;
        }

        else
        {
            brain.ChangeState(EState.Idle);
        }
    }

    void AttackUpdate()
    {

    }
}