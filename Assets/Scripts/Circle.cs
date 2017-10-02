﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public float currentSpeed = 4f;

    void Update()
    {
        Vector3 pos = transform.position;
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);

        if (pos.x <= -12)
            Destroy(gameObject);
    }
}
