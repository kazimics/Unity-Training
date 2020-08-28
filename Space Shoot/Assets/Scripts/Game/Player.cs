using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5;
    private float speedMultiply = 2;
    [SerializeField]
    private GameObject _laserPrefabs;
    [SerializeField]
    private GameObject _tribleShotPrefabs;
    [SerializeField]
    private float _fireRate = 0.15f;
    private float _canFire = -1.0f;
    [SerializeField]
    private int lives = 3;
    private SpawnManager spawnManager;
    private bool isTripleShotEnable = false;
    private bool isShieldEnable = false;
    [SerializeField]
    private GameObject shield, leftEngine, rightEngine;
    private int score;
    private UIManager uiManager;
    [SerializeField]
    private AudioSource laserAudio;

    void Start()
    {
        score = 0;
        transform.position = new Vector3(-4.48f, -2.07f, 0);
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    void Update()
    {
        CaculateMovemoment();
        Fire();
    }

    void CaculateMovemoment()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float maxY = 5.48f;
        float minY = -3.48f;
        float maxX = 5.31f;
        float minX = -13.55f;

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, minY, maxY), 0);


        if (transform.position.x >= maxX)
        {
            transform.position = new Vector3(minX, transform.position.y, 0);
        }
        else if (transform.position.x <= minX)
        {
            transform.position = new Vector3(maxX, transform.position.y, 0);
        }
    }

    void Fire()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;
            if (isTripleShotEnable == true)
            {
                Instantiate(_tribleShotPrefabs, transform.position + new Vector3(0, 0.14f, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(_laserPrefabs, transform.position + new Vector3(0, 1.14f, 0), Quaternion.identity);
            }
            laserAudio.Play();
        }
    }

    public void Damage()
    {
        if (isShieldEnable == true)
        {
            isShieldEnable = false;
            shield.SetActive(false);
            return;
        }
        lives--;
        if(lives == 2)
        {
            leftEngine.SetActive(true);
        }
        else if(lives == 1)
        {
            rightEngine.SetActive(true);
        }
        uiManager.UpdateLives(lives);
        if (lives < 1)
        {
            spawnManager.OnPlayerdie();
            Destroy(gameObject);
            uiManager.GameOver();
        }
    }

    public void TripleShotPowerUp()
    {
        isTripleShotEnable = true;
        StartCoroutine(TripleShotPowerDownRuntine());
    }

    public void SpeedPowerUp()
    {
        _speed *= speedMultiply;
        StartCoroutine(SpeedPowerDownRuntine());
    }

    public void ShieldPowerUp()
    {
        isShieldEnable = true;
        shield.SetActive(true);
    }

    IEnumerator SpeedPowerDownRuntine()
    {
        yield return new WaitForSeconds(5.0f);
        _speed /= speedMultiply;
    }

    IEnumerator TripleShotPowerDownRuntine()
    {
        yield return new WaitForSeconds(5.0f);
        isTripleShotEnable = false;
    }

    public void AddScore(int points)
    {
        score += points;
        uiManager.UpdateScore(score);
    }
}
