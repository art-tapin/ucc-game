using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static bool IsInteractable(this RaycastHit2D hit)
    {
        //Debug.Log("1");
        return hit.transform.GetComponent<Interactable>();
    }

    public static void Interact(this RaycastHit2D hit)
    {
        //Debug.Log("2");
        hit.transform.GetComponent<Interactable>().Interact();
    }
}
