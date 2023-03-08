using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject interactIcon;
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;

    private Vector2 boxSize = new Vector2(1f, 1.5f);    

    // Start is called before the first frame update
    private void Start()
    {
        interactIcon.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
            if (Input.GetKeyDown(KeyCode.E)) {
                CheckInteraction();
            }
        
            dirX = Input.GetAxisRaw("Horizontal");

            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                //jumpSoundEffect.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            UpdateAnimationState();                
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (DialogueManager.isActive == true)
        {
            state = MovementState.idle;
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
        }
        

        if (dirX > 0f && DialogueManager.isActive == false)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f && DialogueManager.isActive == false)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }
    
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    public void OpenInteractableIcon() {
        interactIcon.SetActive(true);
    }

    public void CloseInteractableIcon() {
        interactIcon.SetActive(false);
    }

    private void CheckInteraction() {

        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxSize, 0, Vector2.zero);

        if (hits.Length > 0) {
            Debug.Log("hits.Length: " + hits.Length);
            foreach(RaycastHit2D rc in hits) { 
                
                if (rc.IsInteractable()) {
                    Debug.Log("Interactable: " + rc.collider.name);
                    rc.Interact();
                    // if more than one object in range remove this return
                    //return;
                }                
            }            
        }
    }
    public float getSpeed()
    {
        return moveSpeed;
    }
    public void setSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }
}