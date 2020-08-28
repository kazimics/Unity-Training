using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 4.0f;
    private float minY = -4.5f;
    private float maxY = 6.7f;
    private Player _player;
    private Animator anim;
    private AudioSource audioSource;
    private float _fireRate = 0.05f;
    private float _canFire = -1.0f;
    [SerializeField]
    private GameObject enemyLaserPrefabs;
    [SerializeField]
    private AudioClip laserClip;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(Fire());
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y <= minY)
        {
            float randomX = Random.Range(-12.6f, 4.4f);
            transform.position = new Vector3(randomX, maxY, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }
            EnemyExplosion();
        }

        if (other.tag == "Laser")
        {
            EnemyExplosion();
            if (_player != null)
            {
                _player.AddScore(10);
            }
            Destroy(other.gameObject);
        }
    }

    private void EnemyExplosion()
    {
        anim.SetTrigger("OnEnemyDeath");
        speed = 0.5f;
        Destroy(GetComponent<Collider2D>());
        audioSource.Play();
        Destroy(gameObject, 1.6f);
    }

    IEnumerator Fire()
    {
        while (true)
        {
            Instantiate(enemyLaserPrefabs, transform.position + new Vector3(0, -1.61f, 0), Quaternion.identity);
            AudioSource.PlayClipAtPoint(laserClip, transform.position, 1f);
            yield return new WaitForSeconds(Random.Range(3, 7));
        }
    }
}
