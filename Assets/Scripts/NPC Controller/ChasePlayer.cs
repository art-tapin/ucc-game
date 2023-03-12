using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChasePlayer : MonoBehaviour
{
    public Transform Player;
    int MoveSpeed = 4;
    int MaxDist = 10;
    int MinDist = 5;

    void FixedUpdate()
    {
        transform.LookAt(Player);

        if (Vector2.Distance(transform.position, Player.position) >= MinDist)
        {
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;

            if (Vector2.Distance(transform.position, Player.position) <= MaxDist)
            {
                Debug.Log("Do something");
            }
        }
    }
}
