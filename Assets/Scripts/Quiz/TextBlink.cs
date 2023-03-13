using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextBlink : MonoBehaviour
{
    TextMeshProUGUI text;
    public float blinkFadeInTime = 0.001f;
    public float blinkFadeOutTime = 0.001f;
    public float blinkDuration = 0.005f;
    private float timeChecker = 0;
    private Color oldColor;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        oldColor = text.color;
    }

    // Update is called once per frame
    void Update()
    {
        timeChecker += Time.fixedDeltaTime;
        //timeChecker += Time.deltaTime;
        if (timeChecker < blinkFadeInTime)
        {
            text.color = new Color(
                oldColor.r,
                oldColor.g,
                oldColor.b,
                timeChecker / blinkFadeInTime
            );
        }
        else if (timeChecker < blinkFadeInTime + blinkDuration)
        {
            text.color = new Color(oldColor.r, oldColor.g, oldColor.b, 1);
        }
        else if (timeChecker < blinkFadeInTime + blinkDuration + blinkFadeOutTime)
        {
            text.color = new Color(
                oldColor.r,
                oldColor.g,
                oldColor.b,
                1 - (timeChecker - blinkFadeInTime - blinkDuration) / blinkFadeOutTime
            );
        }
        else
        {
            timeChecker = 0;
        }
    }
}
