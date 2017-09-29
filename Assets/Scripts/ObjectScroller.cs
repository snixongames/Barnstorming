using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeX;

    public Vector3 startPos;

    // Use this for initialization
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, tileSizeX);
        transform.position = startPos + Vector3.left * newPos;
    }
}
