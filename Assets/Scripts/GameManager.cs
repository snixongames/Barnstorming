using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject circle;
    public GameObject[] buildings;
    float spawnTime = 1f;
    public float spawnChance;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("CircleSpawn", 4, spawnTime);
        InvokeRepeating("BuildingSpawn", 3, spawnTime);
    }

    void Update()
    {
        spawnChance = Random.Range(1, 11);
    }

    void CircleSpawn()
    {
        if (Plane.health <= 0f)
            return;

        //set where the circle will spawn
        float circleSpawnPoint = Random.Range(4f, 7.5f);
        transform.position = new Vector3(12, circleSpawnPoint, 0);

        //will spawn an enemy on 60% chance
        if (spawnChance >= 5)
            Instantiate(circle, transform.position, Quaternion.identity);
    }

    void BuildingSpawn()
    {
        if (Plane.health <= 0f)
            return;

        //will spawn windmill on 30% chance
        if (spawnChance >= 8)
            Instantiate(buildings[1], new Vector3(12, 2, 0), Quaternion.identity);

        //will spawn barn on 20% chance. 50% chance neither barn or windmill will spawn
        if (spawnChance <= 2)
            Instantiate(buildings[0], new Vector3(12, 1.25f, 0), Quaternion.identity);
    }
}
