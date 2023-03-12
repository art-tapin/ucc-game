using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMenu : MonoBehaviour
{
    public void Scene1()
    {
        SceneManager.LoadScene(2);
    }

    public void Scene2()
    {
        SceneManager.LoadScene(3);
    }

    public void Scene3()
    {
        SceneManager.LoadScene(4);
    }

    public void Credits()
    {
        SceneManager.LoadScene(5);
    }
}
