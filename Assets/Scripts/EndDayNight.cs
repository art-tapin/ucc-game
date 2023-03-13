using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EndDayNight : MonoBehaviour
{
    public Light2D light;
    public DayNightCycleURP daylight;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            daylight.enabled = false;
            light.intensity = 0.3f;
        }
    }
}
