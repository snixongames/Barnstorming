using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject circle;
    public GameObject[] buildings;
    float circleSpawnTime = 1f;
    float buildingSpawnTime = 2f;
    public float spawnChance;

    public static int barnCount;
    public float smallestCount;
    public int millisecondsCount;
    public int secondsCount;
    public int minutesCount;

    float start;

    public Text barntext;
    public Text timetext;

    // Use this for initialization
    void Start()
    {
        barnCount = 10;
        InvokeRepeating("CircleSpawn", 4, circleSpawnTime);
        InvokeRepeating("BuildingSpawn", 3, buildingSpawnTime);
        start = Time.deltaTime;
    }

    void Update()
    {
        barntext.text = "" + barnCount;
        spawnChance = Random.Range(1, 11);

        if (barnCount > 0)
            UpdateTimer();
    }

    void CircleSpawn()
    {
        if (Plane.health <= 0f || Plane.collision == true || barnCount == 0 || Plane.wait == true)
            return;

        //set where the circle will spawn
        float circleSpawnPoint = Random.Range(4.5f, 8.5f);
        transform.position = new Vector3(12, circleSpawnPoint, 0);

        //will spawn an enemy on 60% chance
        if (spawnChance >= 5)
        {
            Instantiate(circle, transform.position, Quaternion.identity);
        }
    }

    void BuildingSpawn()
    {
        if (Plane.health <= 0f || Plane.collision == true || barnCount == 0 || Plane.wait == true)
            return;

        //will spawn windmill on 50% chance
        if (spawnChance >= 6)
            Instantiate(buildings[1], new Vector3(12, 2f, 0), Quaternion.identity);

        //will spawn barn on 40% chance
        if (spawnChance <= 4)
            Instantiate(buildings[0], new Vector3(12, 1.5f, 0), Quaternion.identity);
    }

    void UpdateTimer()
    {
        float timingCount = Time.time - start;
        string min = ((int)timingCount / 60).ToString();
        string sec = (timingCount % 60).ToString("f2");

        timetext.text = min + ":" + sec;
    }
}
