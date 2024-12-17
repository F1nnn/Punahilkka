using SuperTiled2Unity.Editor.LibTessDotNet;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum EnemyState
{
    idle,
    walk,
    run,
    attack
}


public class EnemyController : MonoBehaviour
{

    [SerializeField]
    private EnemyState currentState;
    public float moveSpeed;
    public Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRadius;
    public float attacRadius;
    public Animator anim;
    [SerializeField]
    private int damageToGive;



    void Start()
    {
        currentState = EnemyState.idle;

        myRigidbody = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        target = GameObject.FindWithTag("Player").transform;
    }


    private void FixedUpdate()
    {
        Vector3 forward = transform.TransformDirection(target.transform.position - transform.position);
        Debug.DrawRay(transform.position, forward, Color.red);

        CheckDistance();
    }

    private void CheckDistance()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= chaseRadius && distance > attacRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.run)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                changeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);

                ChangeState(EnemyState.run);

                anim.SetBool("Running", true);
            }
        }
        else if (distance > chaseRadius)
        {
            anim.SetBool("Running", false);

            ChangeState(EnemyState.idle);
        }
        else if (distance < chaseRadius)
        {
            PlayerHealtManager.instance.HurtPlayer(damageToGive);
        }
    }

    private void SetAnimFloat(Vector2 setVector)
    {
        anim.SetFloat("MoveX", setVector.x);
        anim.SetFloat("MoveY", setVector.y);
    }

    private void changeAnim(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                print("oikealla");
                // 1, 0
                SetAnimFloat(Vector2.right);
            }
            else if(direction.x < 0)
            {
                print("vasemmalla");
                // -1, 0
                SetAnimFloat(Vector2.left);
            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if(direction.y > 0)
            {
                // 0, 1
                SetAnimFloat(Vector2.up);
            }
            else if (direction.y < 0)
            {
                // 0, -1
                SetAnimFloat(Vector2.down);
            }
        }
    }

    private void ChangeState(EnemyState newState)
    {
        if(currentState != newState)
        {
            currentState = newState;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere (transform.position, attacRadius);
    }
}
