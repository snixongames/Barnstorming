using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public static int health = 7;

    public static float currentSpeed;
    public int fakeHealth;
    float antiSpeed;
    float maxSpeed = 12f;
    float minSpeed = 5f;
    float accelerateSpeed = 0.02f;
    float deccelerateSpeed = 0.02f;

    float rateOfDecrease;
    public static bool collision = false;
    public static bool wait;

    public GameObject[] circles;

    // Use this for initialization
    void Start()
    {
        wait = false;
        currentSpeed = minSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        fakeHealth = health;
        if (collision == false)
        {
            Movement();
            Boost();
        }

        if (GameManager.barnCount <= 0)
        {
            collision = true;

            if (currentSpeed > 0)
                currentSpeed = currentSpeed - deccelerateSpeed;

            Vector3 pos = transform.position;
            if (pos.y > 0.7)
                transform.Translate(Vector2.down * currentSpeed * Time.deltaTime);
        }

        if (health <= 0)
        {
            AudioManager.instance.PlaneBreak();
            AudioManager.dead = true;
            collision = true;
            currentSpeed = 0;
        }

        EngineSound();
    }

    void EngineSound()
    {
        if (health >= 5)
        {
            AudioManager.instance.PlaneHighHealth();
        }

        if (health <= 4 && health >= 2)
        {
            AudioManager.instance.PlaneMedHealth();
        }

        if (health == 1)
        {
            AudioManager.instance.PlaneMedHealth();
        }
    }

    void Movement()
    {
        Vector3 pos = transform.position;
        if (Input.GetKey(KeyCode.UpArrow) && (pos.y <= 8.5))
            transform.Translate(Vector2.up * currentSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.DownArrow) && (pos.y >= 0.5))
            transform.Translate(Vector2.down * currentSpeed * Time.deltaTime);
    }

    void Boost()
    {
        // on space down increase speed. otherwise decrease speed
        if (Input.GetKey(KeyCode.Space) && (currentSpeed < maxSpeed))
            currentSpeed = currentSpeed + accelerateSpeed;
        else if (currentSpeed > minSpeed)
            currentSpeed = currentSpeed - deccelerateSpeed;
    }

    IEnumerator Knockback(float timeTaken)
    {
        collision = true;
        currentSpeed = currentSpeed * -1;
        yield return new WaitForSeconds(timeTaken);
        currentSpeed = minSpeed;
        collision = false;
    }

    IEnumerator SpawnWait(float timeTaken)
    {
        wait = true;
        yield return new WaitForSeconds(timeTaken * 3);
        wait = false;
    }

    // if hit then calculate rateOfDecrease with a certain value
    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Barn" || obj.gameObject.tag == "Windmill")
        {
            health--;
            StartCoroutine(Knockback(0.5f));
            StartCoroutine(SpawnWait(0.5f));
            ExplodeAll();
            AudioManager.instance.BuildingHit();
        }
        else if (obj.gameObject.tag == "Circle")
        {
            health--;
            StartCoroutine(Knockback(0.2f));
            StartCoroutine(SpawnWait(0.2f));
        }
        else if (obj.gameObject.tag == "BarnMiddle")
        {
            health++;
            GameManager.barnCount--;
            AudioManager.instance.BarnEnter();
        }
    }

    void ExplodeAll()
    {
        circles = GameObject.FindGameObjectsWithTag("Circle");
        foreach (GameObject circle in circles)
        {
            circle.GetComponent<Circle>().collision = true;
        }
    }
}
