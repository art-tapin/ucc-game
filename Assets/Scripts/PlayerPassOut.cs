using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPassOut : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;

    public GameObject dead;
    public GameObject target;
    public AudioSource deathSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            player.GetComponent<SpriteRenderer>().enabled = false;
            dead.SetActive(true);
            StartCoroutine(DelayedCoroutine());
            deathSound.Play();
            //player.SetActive(true);
        }
    }

    IEnumerator DelayedCoroutine()
    {
        yield return new WaitForSeconds(2f);
        SceneControl.TransitionPlayer(target.transform.position);
    }
}
