using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public bool isStart;
    public bool isSettings;
    public bool isQuit;
    public bool isHowPlay;

    public bool isBack;
    public void OnMouseUp()
    {
        if (isStart)
        {
            SceneManager.LoadScene(1);
        }
        if (isSettings)
        {
            SceneManager.LoadScene(11);
        }
        if (isQuit)
        {
            Application.Quit();
        }

        if (isBack)
        {
            SceneManager.LoadScene(0);
        }

        if (isHowPlay)
        {
            SceneManager.LoadScene(12);
        }
    }
}
