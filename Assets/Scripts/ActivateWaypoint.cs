using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWaypoint : MonoBehaviour
{
    public GameObject waypoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goomba") == true)
        {
            waypoint.SetActive(true);
        }
    }
}
