using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    private Animator birdAnim;
    private bool isFirstTap = true;
    private GameUIManager uIManager;
    private Rigidbody2D rbody;
    private float force = 6.5f;
    private float maxAngle = 30;

    private void Start()
    {
        birdAnim = GameObject.Find("Bird").GetComponent<Animator>();
        uIManager = GameObject.Find("Canvas").GetComponent<GameUIManager>();
        rbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Debug.Log(transform.eulerAngles.z);
        if (Input.GetMouseButtonDown(0))
        {
            if (isFirstTap == true)
            {
                uIManager.readyTap();
                birdAnim.SetBool("isReady", true);
                isFirstTap = false;
            }
            
            rbody.velocity = new Vector2(0, force);
            Vector3 angle = transform.eulerAngles;
            angle.z += rbody.velocity.y;
            angle.z = angle.z - 180;
            if(angle.z > 180)
            {
                angle.z -= 180;
            }
            else
            {
                angle.z += 180;
            }
            angle.z = Mathf.Clamp(angle.z, -maxAngle, maxAngle);
            transform.eulerAngles = angle;
        }
    }

}