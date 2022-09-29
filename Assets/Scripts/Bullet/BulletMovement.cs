using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;

    public float BulletSpeed;
    public float maxVelocity = 20;

    void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void InitBullet()
    {
        myRigidbody2D.AddForce(transform.up * BulletSpeed);
    }

    public void SetVelocity(Vector2 velocity)
    {
        myRigidbody2D.velocity = velocity;
    }

    public void DisableMovement()
    {
        myRigidbody2D.constraints = RigidbodyConstraints2D.FreezePosition;
    }

    private void Update()
    {
        ClampVelocity();
    }

    private void ClampVelocity()
    {
        myRigidbody2D.velocity = Vector2.ClampMagnitude(myRigidbody2D.velocity, maxVelocity);
    }
}
