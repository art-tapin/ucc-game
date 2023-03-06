using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMenu : MonoBehaviour
{

    //private bool isPlayClicked;
    //public Animator animator;

    public void Scene1()
    {
        SceneManager.LoadScene(1);
        //isPlayClicked = PlayerPrefs.GetInt("ZoomOutScene", 0) == 1;
        //animator.SetBool("zoomOutScene", !isPlayClicked);
        //Debug.Log("%%%%%%%%%%%%%%%%%%%%%%%%%%%");
    }

    public void Scene2()
    {
        SceneManager.LoadScene(2);
       // PlayerPrefs.SetInt("ZoomOutScene", 1);
    }

    public void Scene3()
    {
        SceneManager.LoadScene(3);
    }
}
