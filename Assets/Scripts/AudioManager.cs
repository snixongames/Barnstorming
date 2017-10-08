using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    AudioSource sounds;

    public float[] lastPlay;

    public int numOfAudio = 9;

    public AudioClip barnEnter;
    public AudioClip buildingHit;
    public AudioClip buttonHover;
    public AudioClip buttonPress;
    public AudioClip circleHit;
    public AudioClip planeBreak;
    public AudioClip planeHighHealth;
    public AudioClip planeLowHealth;
    public AudioClip planeMedHealth;

    public static bool dead;

    // Use this for initialization
    void Start()
    {
        dead = false;
        instance = this;
        sounds = GetComponent<AudioSource>();
        lastPlay = new float[numOfAudio];
    }

    public void BarnEnter()
    {
        if ((lastPlay[0] + (barnEnter.length)) <= Time.timeSinceLevelLoad)
        {
            sounds.PlayOneShot(barnEnter);
            lastPlay[0] = Time.timeSinceLevelLoad;
        }
    }

    public void BuildingHit()
    {
        sounds.PlayOneShot(buildingHit);
    }

    public void ButtonHover()
    {
        sounds.PlayOneShot(buttonHover);
    }

    public void ButtonPress()
    {
        sounds.PlayOneShot(buttonPress);
    }

    public void CircleHit()
    {
        if ((lastPlay[4] + (circleHit.length)) <= Time.timeSinceLevelLoad)
        {
            sounds.PlayOneShot(circleHit);
            lastPlay[4] = Time.timeSinceLevelLoad;
        }
    }

    public void PlaneBreak()
    {
        if (dead == false)
            sounds.PlayOneShot(planeBreak);
    }

    public void PlaneHighHealth()
    {
        if ((lastPlay[6] + (planeHighHealth.length)) <= Time.timeSinceLevelLoad)
        {
            sounds.PlayOneShot(planeHighHealth);
            lastPlay[6] = Time.timeSinceLevelLoad;
        }
    }

    public void PlaneLowHealth()
    {
        if ((lastPlay[7] + (planeLowHealth.length)) <= Time.timeSinceLevelLoad)
        {
            sounds.PlayOneShot(planeLowHealth);
            lastPlay[7] = Time.timeSinceLevelLoad;
        }
    }

    public void PlaneMedHealth()
    {
        if ((lastPlay[8] + (planeMedHealth.length)) <= Time.timeSinceLevelLoad)
        {
            sounds.PlayOneShot(planeMedHealth);
            lastPlay[8] = Time.timeSinceLevelLoad;
        }
    }
}
