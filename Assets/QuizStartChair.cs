using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizStartChair : Interactable
{
    public GameObject player;    
    public GameObject sittingPlayer;   
    private bool isSitting;

    public GameObject quiz;
    public Camera cam1;
    public Camera cam2;
    public GameObject table;
    public GameObject platform;
    public GameObject curtain;
    public GameObject icon;
    public Animator animator;
    public AudioSource audioSource;

    //public Light[] lights;
    public GameObject lightOrigin;
    

    public override void Interact()
    {
        //throw new System.NotImplementedException();
        Debug.Log("Interacting with QuizStartChair");
        if (isSitting)
        {
                      
            player.GetComponent<SpriteRenderer>().enabled = false;
            player.GetComponent<PlayerMovement>().enabled = false;
            icon.GetComponent<SpriteRenderer>().enabled = false;
            sittingPlayer.GetComponent<SpriteRenderer>().enabled = true; 

            cam1.enabled = false;
            cam2.enabled = true;

            // invoke fatherscene cinecamera
            audioSource.Play();


            curtain.GetComponent<Animator>().enabled = true;

            table.GetComponent<WaypointFollower>().enabled = true;
            platform.GetComponent<WaypointFollower>().enabled = true;

            quiz.SetActive(true);


            // access the light origin and enable the bool inside the script

            //lightOrigin.GetComponent<LightControl>().enabled = true;
            lightOrigin.GetComponent<LightControl>().turnOnFlag = true;
            lightOrigin.GetComponent<LightControl>().focuseFlag = true;

            animator.SetBool("isOpen", true);
            //lightOrigin.GetComponent<Lightfocusing>().enabled = true;



            //System.Threading.Thread.Sleep(1000);
            //lights.SetActive(true);

            
            //
            //quizTrigger.SetActive(false);
            //quizTrigger.GetComponent<QuizTrigger>().enabled = true;
            Debug.Log("Sitting");




        }
        else {
            sittingPlayer.GetComponent<SpriteRenderer>().enabled = false;
            
            //player.SetActive(false);
            player.GetComponent<SpriteRenderer>().enabled = true;
            player.GetComponent<PlayerMovement>().enabled = true;
            icon.GetComponent<SpriteRenderer>().enabled = true;

            quiz.SetActive(false);
            //quizTrigger.GetComponent<QuizTrigger>().enabled = false;
            //quizTrigger.SetActive(true);
            Debug.Log("Not Sitting");




        }
        isSitting = !isSitting;

    }

    private void Start()
    {
        //throw new System.NotImplementedException();
        sittingPlayer.GetComponent<SpriteRenderer>().enabled = false;
        isSitting = true;
        
        //quiz.SetActive(false);
        //quizTrigger.GetComponent<QuizTrigger>().enabled = false;
        //quizTrigger.SetActive(true);
        cam1.enabled = true;
        cam2.enabled = false;
       //cam2.Camera.SetActive(false);
       

        table.GetComponent<WaypointFollower>().enabled = false;
        platform.GetComponent<WaypointFollower>().enabled = false;
        curtain.GetComponent<Animator>().enabled = false;
        animator.SetBool("isOpen", false);

    }
}
