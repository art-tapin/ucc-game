using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SunsetTrigger : MonoBehaviour
{
    public PlayableDirector timeline;
    public Rigidbody2D player;
    // Start is called before the first frame update
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            timeline.Play();
        }
        Invoke(nameof(stopCutscene), 3f);

    }
    
    private void stopCutscene()
    {
        player.isKinematic = false;
        Destroy(gameObject);
    }
}
