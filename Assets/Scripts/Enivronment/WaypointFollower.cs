using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField]
    private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField]
    private float speed = 1f;

    private void Start()
    {
        GameObject.Find("Platform").GetComponent<WaypointFollower>().enabled = true;
    }

    private void Update()
    {
        if (
            Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position)
            < 0.1f
        )
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                //Debug.Log("1");
                currentWaypointIndex = 0;
                //GameObject.Find("Platform").GetComponent<WaypointFollower>().enabled = true;
            }
            //GameObject.Find("Platform").GetComponent<WaypointFollower>().enabled = false;
            //Debug.Log("2");
        }
        transform.position = Vector2.MoveTowards(
            transform.position,
            waypoints[currentWaypointIndex].transform.position,
            speed * Time.deltaTime
        );
    }
}
