using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    private bool open = true;
    public string boxType;
    private OrderSpawner orderSpawner;
    public Inventory inventory;
    private SpriteRenderer sprite;
    private GameObject player;
    private BoxCollider2D playerbox;
    private BoxCollider2D boxcollider;
    public AudioSource emptySound;
    public AudioSource addSound;

    // Start is called before the first frame update
    void Start()
    {
        orderSpawner = FindObjectOfType<OrderSpawner>();
        boxcollider = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerbox = player.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (boxcollider.IsTouching(playerbox) && open)
        {
            open = false;
            switch (boxType)
            {
                case "addBurgers":
                    inventory.increaseBurger(1);
                    addSound.Play();
                    break;
                case "addChips":
                    inventory.increaseChips(1);
                    addSound.Play();
                    break;
                case "addMilkshakes":
                    inventory.increaseMilkshake(1);
                    addSound.Play();
                    break;
                case "check":
                    orderSpawner.check();
                    break;
                case "empty":
                    emptySound.Play();
                    inventory.empty();

                    break;
            }
        }
        if (!open && !boxcollider.IsTouching(playerbox))
        {
            open = true;
        }
    }
}
