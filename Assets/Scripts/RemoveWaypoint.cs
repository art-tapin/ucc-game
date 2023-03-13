using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveWaypoint : MonoBehaviour
{
    public GameObject waypoint;
    public GameObject enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goomba") == true)
        {
            waypoint.SetActive(false);
            enemy.GetComponent<GoombaWaypoint>().enabled = false;
        }
    }
}
