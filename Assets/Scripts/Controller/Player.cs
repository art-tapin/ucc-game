using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 7f;

    [SerializeField]
    private float jumpTakeOffSpeed = 7f;
    private bool isGrounded = false;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;

    private States state
    {
        get { return (States)animator.GetInteger("state"); }
        set { animator.SetInteger("state", (int)value); }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        if (isGrounded)
        {
            state = States.idle;
        }

        if (Input.GetButton("Horizontal"))
        {
            Run();
        }

        if (Input.GetButton("Jump") && isGrounded)
        {
            Jump();
        }
    }

    private void Run()
    {
        if (isGrounded)
        {
            state = States.run;
        }

        Vector3 dir = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(
            transform.position,
            transform.position + dir,
            maxSpeed * Time.deltaTime
        );

        sprite.flipX = dir.x < 0.0f;
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpTakeOffSpeed, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 1.8f);
        isGrounded = collider.Length > 1;

        if (!isGrounded)
        {
            state = States.jump;
        }
    }
}

public enum States
{
    idle,
    run,
    jump
}
