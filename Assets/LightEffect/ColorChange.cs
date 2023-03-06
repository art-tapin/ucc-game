using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ColorChange : MonoBehaviour
{
    public Light2D sunLight;
    public Color sunColor;
    public SpriteRenderer sun;
    private int callCount = 1;
    public Light2D globalLight;
    
    // Start is called before the first frame update
    void Start()
    {
        sunLight = gameObject.GetComponent<Light2D>();
        sun = gameObject.GetComponent<SpriteRenderer>();
        sunColor.r = 1;
        sunColor.g = 1;
        sunColor.b = 1;
        sunColor.a = 1;
        sunLight.color = sunColor;
        sun.color = sunColor;
    }

    public void ChangeColor()
    {
        Debug.Log("Invoked");
        switch (callCount)
        {
            case 1:
                globalLight.intensity -= 0.1f;
                sunColor.r = 1;
                sunColor.g = 0.8235f;
                sunColor.b = 0.7764f;
                sunLight.color = sunColor;
                sun.color = sunColor;
                callCount++;
                break;
            case 2:
                globalLight.intensity -= 0.1f;
                sunColor.r = 1;
                sunColor.g = 0.745f;
                sunColor.b = 0.6745f;
                sunLight.color = sunColor;
                sun.color = sunColor;
                callCount++;
                break;
            case 3:
                globalLight.intensity -= 0.1f;
                sunColor.r = 1;
                sunColor.g = 0.5921f;
                sunColor.b = 0.4862f;
                sunLight.color = sunColor;
                sun.color = sunColor;
                callCount++;
                break;
            case 4:
                globalLight.intensity -= 0.1f;
                sunColor.r = 1f;
                sunColor.g = 0.4745f;
                sunColor.b = 0.3372f;
                sunLight.color = sunColor;
                sun.color = sunColor;
                callCount++;
                break;
        case 5:
            globalLight.intensity -= 0.1f;
            // sunColor.r = 1;
            // sunColor.g = 0.33f;
            // sunColor.b = 0.21f;
            sun.color = new Color(0.6823f, 0.2823f, 0.1647f, 1);
            break;
        }
    }
}
