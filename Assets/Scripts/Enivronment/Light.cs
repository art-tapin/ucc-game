using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : Interactable
{
    // public Sprite on;
    // public Sprite off;
    //
    // public SpriteRenderer sprite;
    public GameObject[] lights;
    private bool isOff;

    public override void Interact()
    {
        if (isOff)
        {
            // sprite.sprite = off;
            Debug.Log("OFF");
            lights[0].GetComponent<UnityEngine.Light>().enabled = false;
            lights[1].GetComponent<UnityEngine.Light>().enabled = false;
            // TODO - Add scene change to Hallway
            // TODO - Add sound effect
        }
        else
        {
            // sprite.sprite = on;
            Debug.Log("ON");
            lights[0].GetComponent<UnityEngine.Light>().enabled = true;
            lights[1].GetComponent<UnityEngine.Light>().enabled = true;
            //GameObject.Find("Door_Closed_Bedroom").GetComponent<SpriteRenderer>().enabled = false;
        }
        isOff = !isOff;
    }

    private void Start()
    {
        lights = GameObject.FindGameObjectsWithTag("Light");
        // lights[0].GetComponent<UnityEngine.Light>()
        Debug.Log(lights[0].name + lights[1].name);
        // sprite = gameObject.GetComponent<SpriteRenderer>();
        // sprite.sprite = off;
        isOff = true;
        //GameObject.Find("Door_Closed_Bedroom").GetComponent<SpriteRenderer>().enabled = false;
    }
}