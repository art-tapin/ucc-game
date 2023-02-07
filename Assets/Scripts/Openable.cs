using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Openable : Interactable
{
    public Sprite open;
    public Sprite closed;

    private SpriteRenderer sr;
    private bool isOpen;

    //sprite = GetComponent<SpriteRenderer>();

    public override void Interact()
    {
        if (isOpen)
        {
            sr.sprite = closed;
        }
        else
        {
            sr.sprite = open;
        }

        isOpen = !isOpen;
    }

    private void start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = closed;
        ;
    }
}
