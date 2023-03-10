using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMusic : MonoBehaviour
{
    public AudioSource audio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    if (collision.gameObject.CompareTag("Player") == true) {
        audio.Play();
        }
    }
}

