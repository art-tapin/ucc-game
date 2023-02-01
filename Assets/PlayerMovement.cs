using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    private float dirX;

    [SerializeField] private LayerMask jumpableGround;

    private static readonly int Running = Animator.StringToHash("running");

    private enum MovementState
    {
        idle,
        running,
        jumping,
        falling
    }
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveSpeed * dirX, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;
        
        switch (dirX)
        {
            case > 0:
                state = MovementState.running;
                sprite.flipX = false;
                break;
            case < 0:
                state = MovementState.running;
                sprite.flipX = true;
                break;
            default:
                state = MovementState.idle;
                break;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int) state);
    }

    bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center,
            coll.bounds.size,
            0f,
            Vector2.down,
            .1f,
            jumpableGround);
    }
}