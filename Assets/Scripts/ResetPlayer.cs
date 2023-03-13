using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject bowser;
    public GameObject text;
    public GameObject endScene1,
        endscene2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            player.GetComponent<PlayerMovement>().enabled = true;
            bowser.GetComponent<SpriteRenderer>().flipX = true;
            text.SetActive(true);
            endScene1.SetActive(true);
            endscene2.SetActive(true);
        }
    }
}
