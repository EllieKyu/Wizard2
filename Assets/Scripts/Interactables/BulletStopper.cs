using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStopper : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");

        if (collision.collider.CompareTag("Bullet"))
        {
            collision.gameObject.GetComponentInChildren<BulletMovement>().DisableMovement();
            collision.transform.root.parent = transform;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trig Enter");

        if (other.CompareTag("Bullet"))
        {
            other.gameObject.GetComponentInChildren<BulletMovement>().DisableMovement();
            other.transform.root.parent = transform;
        }
    }
}
