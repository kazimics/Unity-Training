using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private float speed = 3.0f;
    [SerializeField]
    private int powerupID;
    [SerializeField]
    private AudioClip powerupClip;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -5.6f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(powerupClip, transform.position, 1f);
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                switch (powerupID)
                {
                    case 0:
                        player.TripleShotPowerUp();
                        break;
                    case 1:
                        player.SpeedPowerUp();
                        break;
                    case 2:
                        player.ShieldPowerUp();
                        break;
                    default:
                        Debug.Log("default");
                        break;
                }

            }
            Destroy(gameObject);
        }
    }
}
