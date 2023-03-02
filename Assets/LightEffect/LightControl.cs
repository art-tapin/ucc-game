using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightControl : MonoBehaviour
{
    // Start is called before the first frame update
    private Light2D[] lights;
    private LightFocusing[] controlList;
    private bool isTurnedOn;
    public bool turnOnFlag;
    public bool focuseFlag;
    void Start()
    {
        lights = gameObject.GetComponentsInChildren<Light2D>();
        controlList = gameObject.GetComponentsInChildren<LightFocusing>();
        Debug.Log(lights.ToString());
        foreach (var l in lights)
        {
            l.enabled = isTurnedOn;
        }
    }

    void SwitchLight()
    {
        foreach (var l in lights)
        {
            l.enabled = !isTurnedOn;
        }

        isTurnedOn = !isTurnedOn;
    }

    void Focuse()
    {
        foreach (var focus in controlList)
        {
            focus.isStart = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isTurnedOn ^ turnOnFlag)
        {
            SwitchLight();
        }

        if (focuseFlag)
        {
            Focuse();
        }
    }
}
