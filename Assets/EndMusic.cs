using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMusic : MonoBehaviour
{
    public AudioSource music;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            music.Stop();
        }
    }
}
