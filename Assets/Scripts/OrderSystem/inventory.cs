using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Inventory : MonoBehaviour
{ 
    public TMP_Text burgersText;
    public TMP_Text chipsText;
    public TMP_Text milkshakeText;
    private int burgers = 0;
    private int chips = 0;
    private int milkshakes =0;

    public void increaseBurger(int amount)
    {
        burgers +=amount;
        update();
    }
    public void increaseChips(int amount)
    {
        chips +=amount;
        update();
    }
    public void increaseMilkshake(int amount)
    {
        milkshakes += amount;
        update();
    }
    public void empty()
    {
        milkshakes = 0;
        burgers = 0;
        chips = 0;
        update();
    }
    public bool check(int burgerAmount, int chipsAmount, int milkshakeAmount)
    {
        if (burgerAmount==burgers && chipsAmount==chips && milkshakeAmount==milkshakes)
        {
            return true;
        }
        return false;
    }
    public void update(){
        burgersText.text = " x "+burgers;
        chipsText.text =" x "+chips;
        milkshakeText.text ="x "+milkshakes;
    }
    void Start()
    {
        update();
    }

}
