using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove : Interactable
{
    public SpriteRenderer door;
    private bool isClosed;
    public GameObject target;

    public override void Interact()
    {
        if (isClosed)
        {
            door.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            door.GetComponent<SpriteRenderer>().enabled = false;
            //WaitForSeconds(.5f);
            SceneControl.TransitionPlayer(target.transform.position);

            door.GetComponent<SpriteRenderer>().enabled = true;
        }
        isClosed = !isClosed;
    }

    private void Start()
    {
        isClosed = false;
    }
}
