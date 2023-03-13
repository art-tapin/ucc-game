using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterviewStart : MonoBehaviour
{
    public GameObject player;
    public GameObject interview;
    public GameObject bowser;

    //public Animator bowserAnim;

    //public AudioSource interviewAudio;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<Animator>().SetInteger("state", 0);
            player.GetComponent<PlayerMovement>().enabled = false;
            interview.SetActive(true);
            bowser.SetActive(true);
            //bowserAnim.SetBool("isTalking", true);
            //interviewAudio.Play();
        }
    }
}
