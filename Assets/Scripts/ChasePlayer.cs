using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChasePlayer : MonoBehaviour
{

    public Transform Player;
    int MoveSpeed = 4;
    int MaxDist = 10;
    int MinDist = 5;

    //private float dirX = 0f;
    /*
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    */

    //private enum MovementState { walk }
    void Start()
    {
        /*
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        */
    }

    void FixedUpdate()
    {
        transform.LookAt(Player);

        if (Vector2.Distance(transform.position, Player.position) >= MinDist)
        {
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;

            if (Vector2.Distance(transform.position, Player.position) <= MaxDist)
            {
                //Here Call any function U want 
                Debug.Log("Do something");
            }

        }

        //UpdateAnimationState();
    }
    /*
    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.walk;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.walk;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.walk;
        }

        anim.SetInteger("state", (int)state);
    }
    */
}