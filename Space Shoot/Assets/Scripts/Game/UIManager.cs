using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text gameOverText;
    [SerializeField]
    private Text restartText;
    [SerializeField]
    private Image livesImage;
    [SerializeField]
    private Sprite[] liveSprites;
    [SerializeField]
    private GameManager gameManager;

    private void Start()
    {
        scoreText.text = "Score:0";
        livesImage.sprite = liveSprites[3];
        gameOverText.gameObject.SetActive(false);
        restartText.gameObject.SetActive(false);
    }

    public void UpdateScore(int playerScore)
    {
        scoreText.text = "Score:" + playerScore.ToString();
    }

    public void UpdateLives(int spritesIndex)
    {
        livesImage.sprite = liveSprites[spritesIndex];
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartText.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());
        gameManager.GameOver();
    }

    IEnumerator GameOverFlickerRoutine()
    {
        while (true)
        {
            gameOverText.text = "GAME OVER!";
            yield return new WaitForSeconds(0.5f);
            gameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
