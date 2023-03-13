using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    public Dialogue trigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            DialogueManager.isActive = true;
            FindObjectOfType<DialogueManager>().StartDialogue(trigger);
            Destroy(gameObject, .5f);
        }
    }
}
