using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using TMPro;

public class Order : MonoBehaviour
{
    public TMP_Text burgersText;
    public TMP_Text chipsText;
    public TMP_Text milkshakeText;
    public int burgers;
    public int chips;
    public int milkshakes;
    Random rand = new Random();
    public int backup;

    // Start is called before the first frame update
    void Start()
    {
        backup = rand.Next(0, 3);
        burgers = rand.Next(0, 5);
        chips = rand.Next(0, 5);
        milkshakes = rand.Next(0, 5);
        if (burgers == 0 && chips == 0 && milkshakes == 0)
        {
            if (backup == 0)
            {
                burgers = rand.Next(1, 6);
            }
            else if (backup == 1)
            {
                chips = rand.Next(1, 6);
            }
            else
            {
                milkshakes = rand.Next(1, 6);
            }
        }
        Debug.Log(burgers);
        burgersText.text = "X " + burgers;
        chipsText.text = "X " + chips;
        milkshakeText.text = "X " + milkshakes;
    }
}
