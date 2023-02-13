using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Elevator : Interactable
{
    public Sprite up;
    public Sprite down;

    public SpriteRenderer sprite;
    private bool isUp;    

    public override void Interact()
    {
        if (isUp)
        {
            sprite.sprite = up;
            Debug.Log("Up");
            GameObject.Find("platform").GetComponent<WaypointFollower>().enabled = true;
            //gameObject.GetComponent<WaypointFollower>().enabled = true;

        }
        else
        {
            sprite.sprite = down;
            Debug.Log("Down");
            GameObject.Find("platform").GetComponent<WaypointFollower>().enabled = true;
            //gameObject.GetComponent<WaypointFollower>().enabled = false;
        }
        isUp = !isUp;
    }

    private void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.sprite = down;
        isUp = false;
        GameObject.Find("platform").GetComponent<WaypointFollower>().enabled = false;
    }
}

