using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeObject : MonoBehaviour
{
    public float shakeDistance = 0.15f;
    public float shakeDuration = 0.3f;
    public float shakeSpeed = 20f;
    private Vector3 originalPosition;
    private float shakeTime = 0f;

    void Start()
    {
        originalPosition = transform.localPosition;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Shake();
        }
    }

    private void Shake()
    {
        shakeTime = 0f;
    }

    void Update()
    {
        if (shakeTime < shakeDuration)
        {
            float perlinNoise = Mathf.PerlinNoise(Time.time * shakeSpeed, 0f);
            float shakeX = (perlinNoise - 0.5f) * 2f * shakeDistance;
            float shakeY = (perlinNoise - 0.5f) * 2f * shakeDistance;
            transform.localPosition = originalPosition + new Vector3(shakeX, shakeY, 0f);
            shakeTime += Time.deltaTime;
        }
        else
        {
            transform.localPosition = originalPosition;
        }
    }
}
