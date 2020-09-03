using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private PlayerController player;
    public Text scoreText;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    void Update()
    {
        DisplayScore();
    }

    void DisplayScore()
    {
        scoreText.text = ": " + player.GetScore().ToString();
    }
}
