using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelLoaderGender : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    private bool gender = false;
    private int buildIndexConstant = 1;

    // Update is called once per frame
    public void SetGender (int qualityIndex)
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

        //Wait
        yield return new WaitForSeconds(transitionTime);

        //Load scene
        SceneManager.LoadScene(levelIndex);
    }
}
