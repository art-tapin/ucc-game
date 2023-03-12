using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class LavaTrigger : MonoBehaviour
{
    public GameObject target;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            SceneControl.TransitionPlayer(target.transform.position);
        }
    }
}
