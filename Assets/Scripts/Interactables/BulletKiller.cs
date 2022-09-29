using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletKiller : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");

        if (collision.collider.CompareTag("Bullet"))
        {
            Destroy(collision.transform.root.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trig Enter");

        if (other.CompareTag("Bullet"))
        {
            Destroy(other.transform.root.gameObject);
        }
    }
}
