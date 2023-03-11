using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectOrder : MonoBehaviour
{
    public OrderSpawner orderSpawner;
    public SpriteRenderer spriteRenderer;
    public Sprite correctSprite;
    public Sprite wrongSprite;
    public float feedbackDuration = 1f;
    private Sprite originalSprite;
    private bool isDisplayingFeedback = false;
    private float feedbackEndTime = 0f;
    public AudioSource correct;
    public AudioSource wrong;

    // Start is called before the first frame update
    void Start()
    {
        // Save the original sprite
        originalSprite = spriteRenderer.sprite;

        // Hide the sprite initially
        spriteRenderer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if feedback is currently being displayed
        if (isDisplayingFeedback && Time.time >= feedbackEndTime)
        {
            // Feedback duration has ended, switch back to the original sprite
            spriteRenderer.sprite = originalSprite;
            spriteRenderer.enabled = true;
            isDisplayingFeedback = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the other object is the player
        if (other.CompareTag("Player"))
        {
            // Check if the answer is correct and show the appropriate sprite
            bool isCorrect = ShowSprite();
            if (isCorrect)
            {
                Debug.Log("Answer is correct!");
                spriteRenderer.sprite = correctSprite;
                correct.Play();
            }
            else
            {
                Debug.Log("Answer is wrong!");
                spriteRenderer.sprite = wrongSprite;
                wrong.Play();
            }

            // Display feedback sprite for feedbackDuration seconds
            //spriteRenderer.enabled = true;
            isDisplayingFeedback = true;
            feedbackEndTime = Time.time + feedbackDuration;
        }
    }

    bool ShowSprite()
    {
        // Check if the answer is correct and show the appropriate sprite
        if (orderSpawner.check())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
