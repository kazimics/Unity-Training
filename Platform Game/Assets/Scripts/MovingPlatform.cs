using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform pointA, pointB;
    private float speed = 2f;
    private bool switching = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (switching == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
        }
        else if (switching == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
        }

        if (transform.position == pointA.position)
        {
            switching = false;
        }
        else if (transform.position == pointB.position)
        {
            switching = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = transform;
        }
    }
}
