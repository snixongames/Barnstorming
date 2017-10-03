using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    public bool play;

    public void onMouseUp()
    {
        if (play)
        {
            SceneManager.LoadScene(1);
        }
    }
}
