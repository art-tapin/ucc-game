using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowserSpeech : MonoBehaviour
{
    public GameObject bowser;

   

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            bowser.SetActive(true);
            Debug.Log("Bowser is here");
        }
    }
}
