using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class itemBox : MonoBehaviour
{ 
    private bool open = true;
    public string boxType;
    private orderSpawner orderSpawner;
    private inventory inventory;
    private SpriteRenderer sprite;
    private GameObject player;
    private BoxCollider2D playerbox;
    private BoxCollider2D boxcollider;  
    // Start is called before the first frame update
    void Start()
    {
       
        orderSpawner = FindObjectOfType<orderSpawner>();
        inventory= FindObjectOfType<inventory>();
        boxcollider = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerbox = player.GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (boxcollider.IsTouching(playerbox) && open) {
            open=false;
            switch (boxType)
            {
                case "addGems":
                    inventory.increaseGems(1);
                    break;
                case "addCherrys":
                    inventory.increaseCherrys(1);
                    break;
                case "check1":
                    orderSpawner.check1();
                    break;
                case "check2":
                    orderSpawner.check2();
                    break;
                case "check3":
                    orderSpawner.check3();
                    break;
                case "empty":
                    inventory.empty();
                    break;
            
            }
        }
        if (!open && !boxcollider.IsTouching(playerbox)){
            open = true;

        }
    } 
}
