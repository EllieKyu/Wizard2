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

    private float suckDirection = 1;

    public float maxForce = 2000;
    public float minForce = 1500;

    public CircleCollider2D myCirlce;

    public float InitialDistance;
    public float CalculationDistance;

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
            var distance = rBody.transform.position - transform.position;
            Vector2 force = distance;
            force = force.normalized;
            force *= Time.deltaTime;
            force *= suckDirection;
            force *= CalculateForce(distance.magnitude);
            InitialDistance = distance.magnitude;

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

    private float CalculateForce(float distanceFromCenter)
    {
        var maxDistance = myCirlce.radius * transform.localScale.x;

        var distanceAlpha = distanceFromCenter / maxDistance;

        CalculationDistance = distanceAlpha;

        if (suckMode == BulletVaccuumMode.Suck)
        {
            distanceAlpha = 1 - distanceAlpha;
        }

        var force = Mathf.Lerp(minForce, maxForce, distanceAlpha);

        print(force);

        return force;
    }
}
