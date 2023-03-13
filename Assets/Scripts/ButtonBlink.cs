using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBlink : MonoBehaviour
{
    Button btn;
    public float blinkFadeInTime = 0.001f;
    public float blinkFadeOutTime = 0.001f;
    public float blinkDuration = 0.005f;
    private float timeChecker = 0;
    private Color oldColor;
    private ColorBlock cb;

    void Start()
    {
        btn = GetComponent<Button>();
        oldColor = btn.colors.normalColor;
        cb = btn.colors;
    }

    // Update is called once per frame
    void Update()
    {
        timeChecker += Time.fixedDeltaTime;
        //timeChecker += Time.deltaTime;
        if (timeChecker < blinkFadeInTime)
        {
            cb.normalColor = new Color(
                oldColor.r,
                oldColor.g,
                oldColor.b,
                timeChecker / blinkFadeInTime
            );
            btn.colors = cb;
        }
        else if (timeChecker < blinkFadeInTime + blinkDuration)
        {
            cb.normalColor = new Color(oldColor.r, oldColor.g, oldColor.b, 1);
            btn.colors = cb;
        }
        else if (timeChecker < blinkFadeInTime + blinkDuration + blinkFadeOutTime)
        {
            cb.normalColor = new Color(
                oldColor.r,
                oldColor.g,
                oldColor.b,
                1 - (timeChecker - blinkFadeInTime - blinkDuration) / blinkFadeOutTime
            );
            btn.colors = cb;
        }
        else
        {
            timeChecker = 0;
        }
    }
}
