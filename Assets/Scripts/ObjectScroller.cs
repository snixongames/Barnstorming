using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeX;

    public Vector3 startPos;
    public Vector3 newPos;

    // Use this for initialization
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Background")
            scrollSpeed = Plane.currentSpeed / 2;

        if (gameObject.tag == "Foreground")
            scrollSpeed = Plane.currentSpeed;

        transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);
        newPos = transform.position;
        if (newPos.x <= startPos.x - tileSizeX)
            transform.position = startPos;

    }
}
