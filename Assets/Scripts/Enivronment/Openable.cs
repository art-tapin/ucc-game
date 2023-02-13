using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Openable : Interactable
{
    public Sprite open;
    public Sprite closed;

    public SpriteRenderer sr;
    private bool isOpen = false;

    //sprite = GetComponent<SpriteRenderer>();

    public override void Interact()
    {
        if (isOpen)
        {
            sr.sprite = closed;
            Debug.Log("Closed");
        }
        else
        {
            sr.sprite = open;
            Debug.Log("Open");
        }

        isOpen = !isOpen;
    }

    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = closed;
        //isOpen = false;
    }
}
