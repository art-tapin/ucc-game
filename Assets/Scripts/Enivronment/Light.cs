using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : Interactable
{
    public Sprite on;
    public Sprite off;

    public SpriteRenderer sprite;
    private bool isOff;

    public override void Interact()
    {
        if (isOff)
        {
            sprite.sprite = off;
            Debug.Log("OFF");
            //GameObject.Find("Door_Closed_Bedroom").GetComponent<SpriteRenderer>().enabled = true;
            // TODO - Add scene change to Hallway
            // TODO - Add sound effect
        }
        else
        {
            sprite.sprite = on;
            Debug.Log("ON");
            //GameObject.Find("Door_Closed_Bedroom").GetComponent<SpriteRenderer>().enabled = false;
        }
        isOff = !isOff;
    }

    private void start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.sprite = off;
        isOff = false;
        //GameObject.Find("Door_Closed_Bedroom").GetComponent<SpriteRenderer>().enabled = false;
    }
}
