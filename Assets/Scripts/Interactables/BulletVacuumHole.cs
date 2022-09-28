using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletVaccuumMode
{
    Suck,
    Blow
}

public class BulletVacuumHole : MonoBehaviour
{
    public List<Rigidbody2D> rigidbody2Ds = new List<Rigidbody2D>();

    public BulletVaccuumMode suckMode;

    public float forcePower = 1500f;

    private float suckDirection = 1;

    // Start is called before the first frame update
    void Start()
    {
        SetSuckDirection();
    }

    private void SetSuckDirection()
    {
        switch (suckMode)
        {
            case BulletVaccuumMode.Suck:
                suckDirection = -1;
                break;
            case BulletVaccuumMode.Blow:
                suckDirection = 1;
                break;
        }
    }

    private void OnValidate()
    {
        SetSuckDirection();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var rBody in rigidbody2Ds)
        {
            Vector2 force = rBody.transform.position - transform.position;
            force = force.normalized;
            force *= forcePower * Time.deltaTime;
            force *= suckDirection;

            rBody.AddForce(force);


        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Bullet"))
        {
            return;
        }

        var rbody = collision.attachedRigidbody;

        if (!rigidbody2Ds.Contains(rbody))
        {
            rigidbody2Ds.Add(rbody);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Bullet"))
        {
            return;
        }

        var rbody = collision.attachedRigidbody;

        if (rigidbody2Ds.Contains(rbody))
        {
            rigidbody2Ds.Remove(rbody);
        }
    }

    private void OnDrawGizmos()
    {
        foreach (var rBody in rigidbody2Ds)
        {
            Vector2 force = rBody.transform.position - transform.position;
            force = force.normalized;
            force *= forcePower * Time.deltaTime;

            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position, transform.position + new Vector3(force.x, force.y, 0));
        }
    }
}
