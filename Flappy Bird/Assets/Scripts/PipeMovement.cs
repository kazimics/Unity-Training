using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    private float speed = 0.5f;

    // Update is called once per frame
    void Update()
    {
        Vector2 v = transform.position;
        v.x -= speed * Time.deltaTime;
        transform.position = v;
    }
}
