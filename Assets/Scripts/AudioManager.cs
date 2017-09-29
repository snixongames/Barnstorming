using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    AudioSource sounds;

    // Use this for initialization
    void Start()
    {
        instance = this;
        sounds = GetComponent<AudioSource>();
    }

    public void Engine()
    {

    }

    public void EngineWobble()
    {

    }

    public void Break()
    {

    }

    public void Collision()
    {

    }

    public void BarnEnter()
    {

    }

    public void CircleExplode()
    {

    }

    public void ButtonChoose()
    {

    }

    public void ButtonPress()
    {

    }
}
