using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class inventory : MonoBehaviour
{ 
    public TMP_Text gemsText;
    public TMP_Text cherrysText;
    private int gems = 0;
    private int cherrys = 0;

    public void increaseGems(int amount)
    {
        gems +=amount;
        update();
    }
    public void increaseCherrys(int amount)
    {
        cherrys +=amount;
        update();
    }
    public void empty()
    {
        gems = 0;
        cherrys = 0;
        update();
    }
    public bool check(int gemAmount, int cherryAmount)
    {
        if (gemAmount==gems && cherryAmount==cherrys)
        {
            return true;
        }
        return false;
    }
    public void update(){
        gemsText.text = " x "+gems;
        cherrysText.text =" x "+cherrys;

    }
    // Start is called before the first frame update
    void Start()
    {
        update();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
