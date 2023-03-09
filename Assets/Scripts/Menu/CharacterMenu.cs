using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMenu : MonoBehaviour
{
    [SerializeField] private GameObject startingAnimation;
    [SerializeField] private GameObject endingAnimation;
    private int buildIndexConstant = 1;
    public float transitionTime = 2f;

    
    void Start()
    {
        startingAnimation.SetActive(true);
        //endingAnimation.SetActive(false);
    }

    public void SetGender (int qualityIndex)
    {
        if (qualityIndex != 0)
        {
            buildIndexConstant = 2;
        }
    }

    public void PlayGame()
    {
        endingAnimation.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + buildIndexConstant));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //Play animation
        endingAnimation.SetActive(true);
        Debug.Log("Transitioning to next level");
        //Wait
        yield return new WaitForSeconds(transitionTime);

        //Load scene
        SceneManager.LoadScene(levelIndex);
    }
}
