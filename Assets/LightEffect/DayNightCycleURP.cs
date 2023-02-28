using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;


public class DayNightCycleURP : MonoBehaviour
{
    // [FormerlySerializedAs("directionalLight")] public UnityEngine.Light globalLight;
    public Light2D globalLight;

    public float defaultTick = 1000;
    public float tick = 1000; // Increasing the tick, increases second rate
    public float seconds = 0;
    public float mins = 0;
    public int hours = 12;
    public int days = 1;
    public bool timeLapse;
    public float timeLapseMultiplier = 0.5f;
    public PlayableDirector timeline;


    // [SerializeField] private Light lighter;


    // Start is called before the first frame update
    void Start()
    {
        globalLight = gameObject.GetComponent<Light2D>();
    }

    // Update is called once per frame
    void FixedUpdate() // we used fixed update, since update is frame dependant. 
    {
        isTimelineDone();

        if (timeLapse)
        {
            tick = defaultTick * timeLapseMultiplier;
        }
        else 
        {
            tick = defaultTick;
        }

        CalcTime();
    }

    public void CalcTime() // Used to calculate sec, min and hours
    {
        if (timeLapse == false)
        {
            seconds += Time.fixedDeltaTime * tick; // multiply time between fixed update by tick
        } 
        else
        {
            mins += Time.fixedDeltaTime * tick;
        } 

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
        
        if (hours >= 20 && hours <= 24) // dusk at 21:00 / 9pm    -   until 22:00 / 10pm
        {
            globalLight.intensity = 1 - (getMins() - 20 * 60) * 0.004167f; //const = 1 / hour difference * 60
            //lighter.intensity = 4;

        }
        if (hours >= 5 && hours <= 11) // Dawn at 6:00 / 6am    -   until 7:00 / 7am
        {
            globalLight.intensity = (getMins() - 5 * 60) * 0.00277f;
            //lighter.intensity = 0;
        }

    }

    private float getMins()
    {
        return hours * 60 + mins;
    }

    public void isTimelineDone()
    {
         if (timeline.state != PlayState.Playing)
        {
            timeLapse = false;
        }
        else timeLapse = true;
    }
}

