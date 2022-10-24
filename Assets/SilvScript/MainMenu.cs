using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public bool isStart;
    public bool isSettings;
    public bool isQuit;

    public bool isBack;
    void OnMouseUp()
    {
        if (isStart)
        {
            Application.LoadLevel(1);
        }
        if (isSettings)
        {
            Application.LoadLevel(8);
        }
        if (isQuit)
        {
            Application.Quit();
        }

        if (isBack)
        {
            Application.LoadLevel(0);
        }
    }
}
