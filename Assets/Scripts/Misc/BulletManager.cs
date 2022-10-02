using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public List<BulletCollision> bullets = new List<BulletCollision>();

    public static BulletManager Instance;

    public int maxBullets = 69;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }

        if (Instance != this)
        {
            Destroy(this);
        }
    }

    public void RegisterBullet(BulletCollision bullet)
    {
        bullets.Add(bullet);

        HandleBullets();
    }

    private void HandleBullets()
    {
        if (bullets.Count > maxBullets)
        {
            var bullet = RemoveBullet(bullets[0]);
            KillBullet(bullet);
        }
    }

    public GameObject RemoveBullet(BulletCollision bullet)
    {
        if (bullets.Contains(bullet))
        {
            bullets.Remove(bullet);
        }

        return bullet.gameObject;
    }

    public void KillBullet(GameObject bullet)
    {
        Destroy(bullet);
    }

}
