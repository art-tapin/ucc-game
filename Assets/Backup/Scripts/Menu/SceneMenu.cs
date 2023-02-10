using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMenu : MonoBehaviour
{
    public void Scene1()
    {
        SceneManager.LoadScene(1);
    }

    public void Scene2()
    {
        SceneManager.LoadScene(2);
    }

    public void Scene3()
    {
        SceneManager.LoadScene(3);
    }
}
