using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public UnityEngine.Light directionalLight;

    public float tick = 1000; // Increasing the tick, increases second rate
    public float seconds = 0;
    public int mins = 0;
    public int hours = 12;
    public int days = 1;

    // [SerializeField] private Light lighter;


    // Start is called before the first frame update
    void Start()
    {
        directionalLight = gameObject.GetComponent<UnityEngine.Light>();
    }

    // Update is called once per frame
    void FixedUpdate() // we used fixed update, since update is frame dependant. 
    {
        CalcTime();
    }

    public void CalcTime() // Used to calculate sec, min and hours
    {
        seconds += Time.fixedDeltaTime * tick; // multiply time between fixed update by tick

        if (seconds >= 60) // 60 sec = 1 min
        {
            seconds = 0;
            mins += 1;
        }

        if (mins >= 60) //60 min = 1 hr
        {
            mins = 0;
            hours += 1;
        }

        if (hours >= 24) //24 hr = 1 day
        {
            hours = 0;
            days += 1;
        }

        ControlDirectionalLight(); // changes post processing volume after calculation
    }
    
    public void ControlDirectionalLight() // used to adjust the post processing slider.
    {
        
        if (hours >= 21 && hours < 22) // dusk at 21:00 / 9pm    -   until 22:00 / 10pm
        {
            directionalLight.intensity = 1 - mins * 0.0167f; // since dusk is 1 hr, we just divide the mins by 60 which will slowly increase from 0 - 1 
            //lighter.intensity = 4;

        }
        if (hours >= 6 && hours < 7) // Dawn at 6:00 / 6am    -   until 7:00 / 7am
        {
            directionalLight.intensity = mins * 0.0167f; // we minus 1 because we want it to go from 1 - 0
            //lighter.intensity = 0;
        }

    }
}

