using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopEnemy : MonoBehaviour
{
    public GameObject enemy;
    //public GameObject waypoint;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Goomba") == true) {
            enemy.GetComponent<GoombaWaypoint>().enabled = false;
            //waypoint.SetActive(false);
        }
    }
}
