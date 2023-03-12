using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject startingAnimation;

    [SerializeField]
    private GameObject endingAnimation;

    void Start()
    {
        startingAnimation.SetActive(true);
        //endingAnimation.SetActive(false);
    }

    public void PlayGame()
    {
        endingAnimation.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
