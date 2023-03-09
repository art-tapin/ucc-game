using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizTrigger : MonoBehaviour
{
   public GameObject quiz;
   public Camera cam1;
   public Camera cam2;
   public GameObject table;
   public GameObject platform;
   public GameObject curtain;
   public Animator animator;
   public AudioSource audioSource;

   private void OnTriggerEnter2D(Collider2D collision) {

    if (collision.gameObject.CompareTag("Player") == true)
    {
        //cam1.Camera.SetActive(false);
        cam1.enabled = false;
        //cam2.Camera.SetActive(true);
        cam2.enabled = true;
        table.GetComponent<WaypointFollower>().enabled = true;
        platform.GetComponent<WaypointFollower>().enabled = true;
        // play audio
        audioSource.Play();

        curtain.GetComponent<Animator>().enabled = true;
        // delay the quiz from appearing
        //table.SetActive(true);

        quiz.SetActive(true);
        animator.SetBool("isOpen", true);
        
        //Destroy(gameObject, .5f);           
    }
   }

   private void Start() {
       quiz.SetActive(false);
       //cam1.Camera.SetActive(true);
       cam1.enabled = true;
       cam2.enabled = false;
       //cam2.Camera.SetActive(false);
       

       table.GetComponent<WaypointFollower>().enabled = false;
        platform.GetComponent<WaypointFollower>().enabled = false;
        curtain.GetComponent<Animator>().enabled = false;
        animator.SetBool("isOpen", false);
       //table.SetActive(false);
       //disble audiosource
    
        audioSource.Stop();
}
}
