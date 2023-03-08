using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public Dialogue start;
    public Dialogue end;
    //private bool next = false;
    public Animator fatherChange;
    //public Animator vader;
    //public SpriteRenderer vaderSprite;
    //public SpriteRenderer fatherSprite;

 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)// && (next == false))
        {
            DialogueManager.isActive = true;
            //fatherChange.SetBool("active", false);
            FindObjectOfType<DialogueManager>().StartDialogue(start);

            //fatherChange.active = true;
            //FindObjectOfType<DialogueManager>().EndDialogue(start);
            //DialogueManager.isActive = false;

            //DialogueManager.isActive = true;
            //FindObjectOfType<DialogueManager>().StartDialogue(end);
            //DialogueManager.isActive = false;
            fatherChange.SetBool("active", true);
            fatherChange.SetBool("idle", true);
            //fatherChange.enabled = false;
            //System.Threading.Thread.Sleep(1500);
            //fatherSprite.enabled = false;
            //vaderSprite.enabled = true;
            Destroy(gameObject, .5f);

            //next = true;
        }
/*
        if (next == true)
        {
            DialogueManager.isActive = true;
            FindObjectOfType<DialogueManager>().StartDialogue(end);
            //DialogueManager.isActive = false;
            //fatherChange.SetBool("fatherScene", false);
            Destroy(gameObject, .5f);
        }
        */
    }
}
