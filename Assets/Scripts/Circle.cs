using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public float currentSpeed;
    bool explode = false;

    public Sprite[] circles;
    public Sprite[] explosions;
    public SpriteRenderer sr;

    public bool collision;
    int num;

    void Start()
    {
        collision = false;
        sr = GetComponentInChildren<SpriteRenderer>();

        num = Random.Range(0, 6);
        sr.sprite = circles[num];
    }

    void Update()
    {
        currentSpeed = (Plane.currentSpeed / 6) * 4;
        Vector3 pos = transform.position;
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);

        if (pos.x <= -18)
            Destroy(gameObject);

        if (collision == true)
            CollisionDetails();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        CollisionDetails();
    }

    void CollisionDetails()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        AudioManager.instance.CircleHit();

        sr.sprite = explosions[num];
        float rotation = Random.Range(0, 360);
        float size = Random.Range(1, 2);
        sr.transform.Rotate(Vector3.forward * rotation);
        sr.transform.localScale = new Vector3(size, size, size);
        collision = false;
    }
}
