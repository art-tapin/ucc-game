using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWakeUp : MonoBehaviour
{
    public GameObject player;
    //public GameObject dead;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            //dead.SetActive(false);
            player.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
