using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyMoment : MonoBehaviour
{
    public float speed;

    Rigidbody2D rb;
    Animator anim;

    public bool IsStatic;//duraðan düþman
    public bool IsWalker;//yürüyen düþman
    public bool IsPatroller;//devriye atan düþman
    public bool IsWalkingRight;
    bool Wait;
    bool IsWaiting;

    public float WaitTime;

    public Transform WallCheck, GroundCheck, PitCheck;
    bool WallDetected,GroundDetected,PitDetected;
    public float detectionRadius;
    public LayerMask WhatIsGround;

    public Transform PointA, PointB;
    bool moveToA, moveToB;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();    
        moveToA = true;
    }

    
    void Update()
    {
        PitDetected = !Physics2D.OverlapCircle(PitCheck.position, detectionRadius, WhatIsGround);
        WallDetected = Physics2D.OverlapCircle(WallCheck.position, detectionRadius, WhatIsGround);
        GroundDetected = Physics2D.OverlapCircle(GroundCheck.position, detectionRadius, WhatIsGround);


        if(PitDetected || WallDetected && GroundDetected)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        if (IsStatic)
        {
            anim.SetBool("Idle", true);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (IsWalker)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            anim.SetBool("Idle", false);
            if (!IsWalkingRight)
            {
                rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
            }
        }
        if (IsPatroller)
        {
            anim.SetBool("Idle", false);
            if (moveToA)
            {
                if (!IsWaiting)
                {
                    rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
                }

                if (Vector2.Distance(transform.position, PointA.position) <= 0.2f)
                {
                    StartCoroutine(Waiting());
                    moveToA = false;
                    moveToB = true;
                    Flip();
                }

            }
            if (moveToB)
            {
                if (!IsWaiting)
                {
                    rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
                }

                if (Vector2.Distance(transform.position, PointB.position) <= 0.2f)
                {
                    StartCoroutine(Waiting());
                    moveToA = true;
                    moveToB = false;
                    Flip();
                }
            }
        }
    }
    IEnumerator Waiting()
    {
        anim.SetBool("Idle", true);
        IsWaiting = true;
        yield return new WaitForSeconds(WaitTime);
        IsWaiting = false;
        anim.SetBool("Idle", false);
    }

    void Flip()
    {
        IsWalkingRight = !IsWalkingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }



    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(WallCheck.position, detectionRadius);
        Gizmos.DrawWireSphere(GroundCheck.position, detectionRadius);
        Gizmos.DrawWireSphere(PitCheck.position, detectionRadius);
    }
}
