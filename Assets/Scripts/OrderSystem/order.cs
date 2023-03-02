using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random; 
using TMPro;
public class order : MonoBehaviour
{
    public TMP_Text gemsText;
    public TMP_Text cherrysText;
    public int gems;
    public int cherrys; 
    Random rand = new Random();
    // Start is called before the first frame update
    void Start()
    {
        gems = rand.Next(0,5);
        cherrys = rand.Next(0,5);
        if (gems==0 && cherrys==0){
            if (rand.Next(0,2)==1){
                gems=rand.Next(1,6);
            }
            else{
                cherrys=rand.Next(1,6);
            }

        }
        gemsText.text = " x "+gems;
        cherrysText.text =" x "+cherrys;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
