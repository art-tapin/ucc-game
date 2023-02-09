using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public Animator camAnim;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            camAnim.SetBool("cutscene1", true);
        }
        Invoke(nameof(stopCutscene), 3f);
    }

    private void stopCutscene()
    {
        camAnim.SetBool("cutscene1", false);
        Destroy(gameObject);
    }
}
