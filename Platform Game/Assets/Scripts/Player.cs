using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float gravity = 1.0f;
    [SerializeField]
    private float jumpHeight = 25.0f;
    private float yVelocity;
    private bool canDoublejump = false;
    private int coins = 0;
    private int lives = 3;
    private UIManager uIManager;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        uIManager = GameObject.FindGameObjectWithTag("UI_Manager").GetComponent<UIManager>();
        if(uIManager == null)
        {
            Debug.LogError("UIManager is null.");
        }
        uIManager.UpdateLivesDisplay(lives);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * speed;
        if (controller.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = jumpHeight;
                canDoublejump = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && canDoublejump == true)
            {
                yVelocity += jumpHeight;
                canDoublejump = false;
            }
            yVelocity -= gravity;
        }
        velocity.y = yVelocity;
        controller.Move(velocity * Time.deltaTime);
    }

    public void AddCoins()
    {
        coins++;
        uIManager.UpdateCoinDisplay(coins);
    }

    public void Damage()
    {
        lives--;
        uIManager.UpdateLivesDisplay(lives);
        if (lives < 1)
        {
            SceneManager.LoadScene(0);
        }
    }
}
