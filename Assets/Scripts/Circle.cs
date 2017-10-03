using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public float currentSpeed;

    void Update()
    {
        currentSpeed = (Plane.currentSpeed / 6) * 4;
        Vector3 pos = transform.position;
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);

        if (pos.x <= -12)
            Destroy(gameObject);
    }
}
