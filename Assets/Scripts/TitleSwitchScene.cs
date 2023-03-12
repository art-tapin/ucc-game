using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSwitchScene : MonoBehaviour
{
    public GameObject animationStart;
    public GameObject animationEnd;
    public int sceneIndex = 1;

    void Start()
    {
        animationStart.SetActive(true);
        StartCoroutine(StartAnimation());
    }

    IEnumerator StartAnimation()
    {
        yield return new WaitForSeconds(5);
        animationEnd.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneIndex);
    }
}
