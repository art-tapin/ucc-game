using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddWaypoint : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject waypoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goomba") == true)
        {
            waypoint.SetActive(true);
            Debug.Log("Waypoint added");
        }
    }

    private void Start()
    {
        waypoint.SetActive(false);
    }
}
