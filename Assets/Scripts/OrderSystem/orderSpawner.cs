using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orderSpawner : MonoBehaviour
{
    private bool notStarted = true;
    inventory inventory;
    public GameObject order;
    private GameObject order1;
    private GameObject player;
    private BoxCollider2D playerbox;
    public GameObject startBox; 
    private BoxCollider2D startCollider;
    private PlayerMovement playerMovement;
    public AudioSource correctSound;
    public AudioSource wrongSound;

    
    Vector3 vector3 = new Vector3(1600,800,0); 
    Transform pannelTransform;
    private int count= 0;
    
    public void begin()
    {

        new1();

    }
    public void end(){
        Debug.Log("end");
        //do collapes
    }
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        playerbox = player.GetComponent<BoxCollider2D>();
        playerMovement = player.GetComponent<PlayerMovement>();
        startCollider = startBox.GetComponent<BoxCollider2D>();
        inventory = FindObjectOfType<inventory>();
        GameObject pannel = GameObject.Find("Canvas");
        pannelTransform = pannel.GetComponent<Transform>();


        

    }
    public void new1(){
        order1 = Instantiate(order,pannelTransform);
        order1.transform.position = vector3;
        order1.transform.localScale = new Vector3(1f,1f,0);
    }


    public void bin(){
        inventory.empty();
    }
    public void check(){
        order temp = order1.GetComponent<order>();
        if (inventory.check(temp.burgers,temp.chips,temp.milkshakes)){
            Destroy(order1);
            playerMovement.setSpeed(playerMovement.getSpeed()*.9f);
            correctSound.Play();

            if (count==10){
                end();
            }
            else 
            {
            new1() ;
            bin();            
            count++;
            }        
        }
        else {
            wrongSound.Play();
        }
    }
    void Update()
    {
        if (notStarted && startCollider.IsTouching(playerbox))
        {
            begin();
            notStarted = false;
        }
    }
    

}
