using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [SerializeField]
    private Image readyImage;

    private void Start()
    {
        readyImage = GameObject.Find("Ready_Image").GetComponent<Image>();
    }

    public void readyTap()
    {
        readyImage.enabled = false;
    }
}
