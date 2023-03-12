using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 0.5f;

    //private float dirX = 0f;
    public Transform Player;
    private SpriteRenderer sprite;
    public float oldPosition;
    public Animator anim;

    //public bool movingRight = false;
    //public bool movingLeft = false;

    // Use this for initialization
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        oldPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 displacement = Player.position - transform.position;
        displacement = displacement.normalized;

        if (Vector2.Distance(Player.position, transform.position) > 1.0f)
        {
            transform.position += (displacement * speed * Time.deltaTime);
            anim.SetBool("isWalking", true);
        }
        /*
                if (transform.position.x > oldPosition)
                {
                    movingRight = true;
                    movingLeft = false;
                    sprite.flipX = false;
                    
                }
                if (transform.position.x < oldPosition)
                {
                    movingRight = false;
                    movingLeft = true;
                    sprite.flipX = true;
                    
                }
                */
    }
}
