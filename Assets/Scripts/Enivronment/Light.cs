using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : Interactable
{
    //public Light lamp1;
    //public Light lamp2;
    private bool isOff;

    public Light[] lights;

    public override void Interact()
    {
        if (isOff)
        {
            Debug.Log("OFF");
            //lamp1.GetComponent<UnityEngine.Light>().enabled = false;
            //if(lamp2 != null) {
            //lamp2.GetComponent<UnityEngine.Light>().enabled = false;

            for(int i = 0; i < lights.Length; i++)
            {
                lights[i].GetComponent<UnityEngine.Light>().enabled = false;
            }
        }
        
        else
        {
            Debug.Log("ON");
            //lamp1.GetComponent<UnityEngine.Light>().enabled = true;
            //if(lamp2 != null) {
            //lamp2.GetComponent<UnityEngine.Light>().enabled = true;
            

            for(int i = 0; i < lights.Length; i++)
            {
                lights[i].GetComponent<UnityEngine.Light>().enabled = true;
            }
        }
        isOff = !isOff;
    }

    private void Start()
    {        
        isOff = false;
        for(int i = 0; i < lights.Length; i++)
            {
                lights[i].GetComponent<UnityEngine.Light>().enabled = false;
            }    
    }
}
