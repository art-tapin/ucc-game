using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightBlinking : MonoBehaviour
{
    public Light2D bulb;
    private float timer = 0;
    public float blinkingInterval = 2;
    bool timerReached = false;
    // Start is called before the first frame update
    void Start()
    {
        bulb = gameObject.GetComponent<Light2D>();
    }

    void SwitchLight()
    {
        bulb.enabled = !bulb.enabled;
    }

    IEnumerator Blink()
    {
        int randomNum = Random.Range(0, 9);
        if (randomNum is 1 or 2 or 3)
        {
            // Debug.Log(randomNum);
            for (int i = 0; i < randomNum; i++)
            {
                SwitchLight();
                yield return new WaitForSeconds(0.05f);
                SwitchLight();
                yield return new WaitForSeconds(0.05f);
                // Debug.Log("--BLink--");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!timerReached)
            timer += Time.deltaTime;
        
        if (!timerReached && timer > blinkingInterval)
        {
            // Debug.Log("Done waiting");
            StartCoroutine(Blink());
            // timerReached = true;
            timer = 0;
        }
        
    }
}
