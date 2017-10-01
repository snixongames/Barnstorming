using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public float currentSpeed = 6;
    float maxSpeed = 15;
    float minSpeed = 1;
    float accelerateSpeed = 0.02f;
    float deccelerateSpeed = 0.01f;

    float rateOfDecrease;
    bool collision = false;

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
        if (collision == true)
        {

        }
    }

    void Movement()
    {
        Vector3 pos = transform.position;
        if (Input.GetKey(KeyCode.UpArrow) && (pos.y <= 7.5))
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

    void Knockback(int timeTaken)
    {
        rateOfDecrease = currentSpeed - minSpeed / timeTaken;
    }

    // if hit then calculate rateOfDecrease with a certain value
    void OnTriggerEnter2D(Collider2D obj)
    {
        collision = true;
        if (obj.gameObject.tag == "Barn" || obj.gameObject.tag == "Windmill")
            Knockback(3);
        else if (obj.gameObject.tag == "Circle")
            Knockback(1);
    }
}
