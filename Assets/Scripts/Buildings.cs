using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : MonoBehaviour {

    public float currentSpeed = 6f;

    void Update()
    {
        Vector3 pos = transform.position;
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);

        if (pos.x <= -12)
            Destroy(gameObject);
    }
}
