using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInstance : MonoBehaviour
{
    public Dialogue trigger;

    private void TextPlay()
    {
        DialogueManager.isActive = true;
        FindObjectOfType<DialogueManager>().StartDialogue(trigger);
        Destroy(gameObject, .5f);
    }
}
