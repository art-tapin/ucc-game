using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite; 
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private static readonly int Running = Animator.StringToHash("running");

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2( moveSpeed * dirX, rb.velocity.y);
        
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        switch (dirX)
        {
            case > 0:
                anim.SetBool(Running, true);
                sprite.flipX = false;
                break;
            case < 0:
                anim.SetBool(Running, true);
                sprite.flipX = true;
                break;
            default:
                anim.SetBool(Running, false);
                break;
        }
    }
}
