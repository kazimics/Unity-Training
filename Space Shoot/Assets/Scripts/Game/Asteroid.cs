using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private float rotateSpeed;
    [SerializeField]
    private GameObject explosionPrefab;
    private SpawnManager spawnManager;

    void Start()
    {
        rotateSpeed = 30.0f;
        spawnManager = GameObject.FindGameObjectWithTag("Spawn_Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            Destroy(GetComponent<Collider2D>());
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            spawnManager.StartSpawning();
            Destroy(gameObject, 0.2f);
        }
    }
}
