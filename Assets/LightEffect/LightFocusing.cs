using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFocusing : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isStart;
    public Transform hehe;
    public Transform target;
    private float angle;
    private float rot = 0;
    private int tick = 100;
    private Light2D light;
    private float distance;
    private float distAdd;
    void Start()
    {
        light = gameObject.GetComponent<Light2D>();
        hehe = gameObject.GetComponent<Transform>();
        // Debug.Log(gameObject.name  + ":" + Vector2.SignedAngle(hehe.localPosition, target.localPosition));
        // Debug.Log(gameObject.name  + ":" + hehe.localPosition);
        // Debug.Log(gameObject.name + ":" + target.localPosition);
        // angle = -Vector2.SignedAngle(hehe.localPosition, target.localPosition);
        // rot = angle / tick;
        distance = Vector2.Distance(target.localPosition, hehe.localPosition);
        distAdd = distance / tick;
        angle = CustomAngle(hehe.localPosition, target.localPosition);
        rot = angle / tick;
        Debug.Log(gameObject.name + ":"+ CustomAngle(hehe.position, target.position));
        // light.pointLightOuterRadius = 20;
        if (hehe.position.x > target.position.x)
        {
            rot = -rot;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            if (tick > 0)
            {
                hehe.Rotate(0, 0, rot, Space.World);
                light.pointLightOuterRadius += distAdd;
            }
            tick--;
        }
        
    }
    
    public float CustomAngle(Vector2 from, Vector2 to)
    {
        float toX = to.x - from.x;
        float toY = to.y - from.y;
        float lightX = 0;
        float lightY = -1;
        Vector2 toVec = new Vector2(toX, toY);
        Vector2 lightVec = new Vector2(lightX, lightY);
        float num = (float) Math.Sqrt((double) lightVec.sqrMagnitude * (double) toVec.sqrMagnitude);
        return (double) num < 1.0000000036274937E-15 ? 0.0f : (float) Math.Acos((double) Mathf.Clamp(Vector2.Dot(lightVec, toVec) / num, -1f, 1f)) * 57.29578f;
    }
}
