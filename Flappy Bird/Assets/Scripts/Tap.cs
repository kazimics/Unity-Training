using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap : MonoBehaviour
{
    [SerializeField]
    private Animator birdAnim;
    private bool isFirstTap = true;
    [SerializeField]
    private GameUIManager uIManager;

    private void Start()
    {
        birdAnim = GameObject.Find("Bird").GetComponent<Animator>();
        uIManager = GameObject.Find("Canvas").GetComponent<GameUIManager>();
    }

    private void OnMouseDown()
    {
        if (isFirstTap == true)
        {
            uIManager.readyTap();
            birdAnim.SetBool("isReady", true);
            birdAnim.applyRootMotion = true;
            isFirstTap = false;
        }

    }
}
