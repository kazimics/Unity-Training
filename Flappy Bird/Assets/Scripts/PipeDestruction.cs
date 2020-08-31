using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeDestruction : MonoBehaviour
{
    private float offscreenX = -1.8f;

    void Update()
    {
        if (transform.position.x < offscreenX)
        {
            Destroy(gameObject);
        }
    }
}
