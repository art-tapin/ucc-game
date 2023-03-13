using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelLoaderGender : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 2f;
    private int buildIndexConstant = 1;

    public void SetGender(int qualityIndex)
    {
        if (qualityIndex != 0)
        {
            buildIndexConstant = 2;
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + buildIndexConstant));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //Play animation
        transition.SetTrigger("Start");
        Debug.Log("Transitioning to next level");
        //Wait
        yield return new WaitForSeconds(transitionTime);

        //Load scene
        SceneManager.LoadScene(levelIndex);
    }
}
