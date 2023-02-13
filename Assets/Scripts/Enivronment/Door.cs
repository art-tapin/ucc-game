using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Door : Interactable
{
    public Sprite open;
    public Sprite closed;

    public SpriteRenderer sprite;
    private bool isClosed;    

    public override void Interact()
    {
        if (isClosed)
        {
            sprite.sprite = closed;
            //Debug.Log("Closed");
            GameObject.Find("Door_Closed_Bedroom").GetComponent<SpriteRenderer>().enabled = true;           
            // TODO - Add scene change to Hallway
            // TODO - Add sound effect
        }
        else
        {
            sprite.sprite = open;
            //Debug.Log("Open");
            GameObject.Find("Door_Closed_Bedroom").GetComponent<SpriteRenderer>().enabled = false;
                  
        }
        isClosed = !isClosed;
    }

    private void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.sprite = closed;
        isClosed = false;
        GameObject.Find("Door_Closed_Bedroom").GetComponent<SpriteRenderer>().enabled = false;
    }
}

