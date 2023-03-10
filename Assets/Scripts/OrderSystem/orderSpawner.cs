using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSpawner : MonoBehaviour
{
    private bool notStarted = true;
    Inventory inventory;
    public GameObject order;
    private GameObject order1;
    private GameObject player;
    private BoxCollider2D playerbox;
    public GameObject startBox; 
    private BoxCollider2D startCollider;
    private PlayerMovement playerMovement;
    public AudioSource correctSound;
    public AudioSource wrongSound;
    public GameObject playerInventory;
    public GameObject endDialogue;
    public GameObject enemies;
    //public AudioSource endMusic;

    
    Vector3 vector3 = new Vector3(1300,800,0); 
    Transform pannelTransform;
    private int count= 0;
    
    public void begin()
    {

        new1();
        playerInventory.SetActive(true);
        inventory = FindObjectOfType<Inventory>();

    }
    public void end(){
        Debug.Log("end");
        playerInventory.SetActive(false);
        //endMusic.Play();
        endDialogue.SetActive(true);
        enemies.SetActive(true);
        player.GetComponent<PlayerMovement>().enabled = false;

        // start end musicGa
        // display dialgoeu box

        // bowser anims
        // scene change
        // 

        //do collapes
    }
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        playerbox = player.GetComponent<BoxCollider2D>();
        playerMovement = player.GetComponent<PlayerMovement>();
        startCollider = startBox.GetComponent<BoxCollider2D>();
        
        GameObject pannel = GameObject.Find("Canvas");
        pannelTransform = pannel.GetComponent<Transform>();
        endDialogue.SetActive(false);
        enemies.SetActive(false);
        

    }
    public void new1(){
        order1 = Instantiate(order,pannelTransform);
        //order1.transform.position = vector3;
        //order1.transform.localScale = new Vector3(1f,1f,0);
    }


    public void bin(){
        inventory.empty();
    }
    public bool check()
{
    Order temp = order1.GetComponent<Order>();
    if (inventory.check(temp.burgers,temp.chips,temp.milkshakes)){
        Destroy(order1);
        playerMovement.setSpeed(playerMovement.getSpeed()*.75f);
        correctSound.Play();

        if (count==1){
            end();
        }
        else 
        {
            new1();
            bin();
            count++;
            
        }
        return true;
    }
    else {
        wrongSound.Play();
        return false;
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
