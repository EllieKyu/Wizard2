using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletKiller : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            collision.gameObject.GetComponentInChildren<BulletCollision>().KillBullet();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            other.gameObject.GetComponentInChildren<BulletCollision>().KillBullet();
        }
    }
}
