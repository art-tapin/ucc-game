using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaWaypoint : MonoBehaviour
{
    public float speed = 0.5f;

    [SerializeField]
    private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    public Transform Player;
    private SpriteRenderer sprite;
    public float oldPosition;
    public Animator anim;
    public GameObject goomba;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        goomba.GetComponent<GoombaWaypoint>().enabled = true;
        anim.SetBool("isWalking", true);
    }

    void LateUpdate()
    {
        oldPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 displacement = Player.position - transform.position;
        displacement = displacement.normalized;

        if (Vector2.Distance(Player.position, transform.position) > 1.0f)
        {
            transform.position += (displacement * speed * Time.deltaTime);
            anim.SetBool("isWalking", true);
        }
        */

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
                //goomba.GetComponent<WaypointFollower>().enabled = true;
            }
            Debug.Log("******************");

            //goomba.GetComponent<GoombaWaypoint>().enabled = false;
        }
        transform.position = Vector2.MoveTowards(
            transform.position,
            waypoints[currentWaypointIndex].transform.position,
            speed * Time.deltaTime
        );
        //goomba.GetComponent<GoombaWaypoint>().enabled = false;
    }
}
