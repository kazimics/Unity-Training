using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLoop : MonoBehaviour
{
    public float speed = 0.2f;
    // 图片离开 Camera 时的 x 值
    public float leaveX;
    // Update is called once per frame
    void Update()
    {
        Vector2 v = transform.position;
        v.x -= speed * Time.deltaTime;
        if (v.x < -leaveX)
        {
            v.x = leaveX;
        }
        transform.position = v;
    }
}
