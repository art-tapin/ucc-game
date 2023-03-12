using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Door : Interactable
{
    public SpriteRenderer door;
    private bool isClosed;

    //public GameObject target;

    public override void Interact()
    {
        if (isClosed)
        {
            door.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            door.GetComponent<SpriteRenderer>().enabled = false;
            //SceneControl.TransitionPlayer(target.transform.position);
        }
        isClosed = !isClosed;
    }

    private void Start()
    {
        isClosed = false;
    }
}
