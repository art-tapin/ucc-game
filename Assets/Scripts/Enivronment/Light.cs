using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : Interactable
{
    public Sprite on;
    public Sprite off;

    public SpriteRenderer sprite;
    public Light light1;
    public Light light2;
    private bool isOff;

    public override void Interact()
    {
        if (isOff)
        {
            sprite.sprite = off;
            Debug.Log("OFF");
            GameObject.Find("Lamp_1").GetComponent<Light>().enabled = false;
            GameObject.Find("Lamp_2").GetComponent<Light>().enabled = false;
            // TODO - Add scene change to Hallway
            // TODO - Add sound effect
        }
        else
        {
            sprite.sprite = on;
            Debug.Log("ON");
            GameObject.Find("Lamp_1").GetComponent<Light>().enabled = true;
            GameObject.Find("Lamp_2").GetComponent<Light>().enabled = true;
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
