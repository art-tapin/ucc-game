using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public GameObject animationStart;
    public GameObject animationEnd;
    public int sceneIndex = 1;

    void Start()
    {
        animationStart.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            animationEnd.SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneIndex);
        }
    }
}
