using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text coinText, livesText;

    public void UpdateCoinDisplay(int coins)
    {
        coinText.text = "Coins: " + coins;
    }
    public void UpdateLivesDisplay(int lives)
    {
        livesText.text = "Lives: " + lives;
    }
}
