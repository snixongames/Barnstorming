using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public static int health = 10;

    public static float currentSpeed = 6f;
    float antiSpeed;
    float maxSpeed = 12f;
    float minSpeed = 5f;
    float accelerateSpeed = 0.02f;
    float deccelerateSpeed = 0.02f;

    float rateOfDecrease;
    public static bool collision = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (collision == false)
        {
            Movement();
            Boost();
        }

        if (GameManager.barnCount == 0)
        {
            collision = true;

            if (currentSpeed > 0)
            currentSpeed = currentSpeed - deccelerateSpeed;

            Vector3 pos = transform.position;
            if (pos.y > 0.7)
            transform.Translate(Vector2.down * currentSpeed * Time.deltaTime);
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

    // if hit then calculate rateOfDecrease with a certain value
    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Barn" || obj.gameObject.tag == "Windmill")
        {
            StartCoroutine(Knockback(0.5f));
        }
        else if (obj.gameObject.tag == "Circle")
        {
            StartCoroutine(Knockback(0.2f));
        }
        else if (obj.gameObject.tag == "BarnMiddle")
        {
            GameManager.barnCount--;
        }
    }
}
