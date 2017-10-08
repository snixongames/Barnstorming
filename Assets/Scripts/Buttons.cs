using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    public bool play;
    public bool menu;
    public bool credits;

    public void onMouseOver()
    {
        AudioManager.instance.ButtonHover();
    }

    public void onMouseUp()
    {
        AudioManager.instance.ButtonPress();
        if (menu)
        {
            SceneManager.LoadScene(0);
        }

        if (play)
        {
            SceneManager.LoadScene(1);
        }

        if (credits)
        {
            SceneManager.LoadScene(2);
        }
    }
}
