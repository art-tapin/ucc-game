using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockIn : Interactable
{
  
    private bool clockedOut;
    public GameObject clockedIn;
    public GameObject startWork;
    public GameObject yourFired;



    public override void Interact()
    {
        if (clockedOut)
        {
            
            Debug.Log("ClockOut");
        }
        
        else
        {
            Debug.Log("ClockedIn");
            clockedIn.SetActive(true);
            startWork.SetActive(true);
            yourFired.SetActive(true);

            
        }
        clockedOut = !clockedOut;
    }

    private void Start()
    {        
       //clockedIn.GetComponent<SpriteRenderer>().enabled = false;
       clockedIn.SetActive(false);
       startWork.SetActive(false);
    }
}
