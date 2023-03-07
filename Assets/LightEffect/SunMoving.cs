using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SunMoving : MonoBehaviour
{
    public SpriteRenderer sun;
    public Transform[] waypoints;
    // Vector3 lastPos;
    int waypointIndex;
    public float step = 0.001f;

    public float timeUnit = 0.1f;
    public float hour = 1;
    public float hourInUnits = 3600;

    public float distance;
    public float dist2;
    
    private float intensity = 0.01f;

    public Light2D light;

    // Start is called before the first frame update
    void Start()
    {
        // lastPos = gameObject.transform.position;
        waypointIndex = 1;
        distance = 0;
        for (int i = 0; i < waypoints.Length - 1; i++)
        {
            distance += Vector2.Distance(waypoints[i].position, waypoints[i + 1].position);
        }

        for (int i = 6; i < waypoints.Length - 1; i++)
        {
            dist2 += Vector2.Distance(waypoints[i].position, waypoints[i + 1].position);
        }
        //step = distance / (hour * hourInUnits * timeUnit);
    }

    public void Move()
    {
        // light.intensity = 0;
        step = distance / (hour * hourInUnits * timeUnit);
        // if (waypointIndex == waypoints.Length)
        // {
        //     waypointIndex = 0;
        //     gameObject.transform.position = waypoints[0].position;
        // }
        if (waypointIndex < waypoints.Length)
        {
            Vector2 waypointPosition = waypoints[waypointIndex].position;

            if (Vector2.Distance(gameObject.transform.position, waypointPosition) > step)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, waypointPosition, step);
                intensity += 0.01f;
                if (intensity < 1)
                {
                    light.intensity = intensity;
                }
                if (waypointIndex >= 8)
                {

                    float red = sun.color.r - ((1 - 0.6823f) / (dist2 / step));
                    float green = sun.color.g - ((1 - 0.2823f) / (dist2 / step));
                    float blue = sun.color.b - ((1 - 0.1647f) / (dist2 / step));
                    sun.color = new Color(red, green, blue, 1);
                    gameObject.GetComponent<Light2D>().color = new Color(red, green, blue, 1);
                }
            }
            else
            {
                gameObject.transform.position = waypointPosition;
                waypointIndex++;
            }
        }
    }

    public void Restart()
    {
        sun.color = new Color(1, 1, 1, 1);
        waypointIndex = 1;
        gameObject.transform.position = waypoints[0].position;
        gameObject.GetComponent<Light2D>().color = new Color(1, 1, 1, 1);
        light.intensity = 0;
        intensity = 0;
    }

    // Update is called once per frame
    // void FixedUpdate()
    // {
    //     
    // }
}
