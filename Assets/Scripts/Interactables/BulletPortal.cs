using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum PortalColor
{
    Blue,
    Orange,
    Pink,
    Green
}

public class BulletPortal : MonoBehaviour
{
    public PortalColor portalColor;

    public GameObject bulletPrefab;

    public SpriteRenderer sprite;

    public void TeleportBullet(Vector2 bulletVelocity, Vector3 bulletForward, Vector3 portalUp, Vector3 hitOffset)
    {
        //Angle between portals
        var vectorAngle = CalculateAngle(portalUp, transform.up);

        //Calculate rotated velocity for bullet
        var newVelocity = Quaternion.AngleAxis(vectorAngle, Vector3.forward) * Vector3.Reflect(bulletVelocity, portalUp);

        //Calculate where on the portal to spawn bullet
        hitOffset = Quaternion.AngleAxis(vectorAngle, Vector3.forward) * hitOffset;
        hitOffset *= transform.localScale.x;

        //Spawn bullet
        var bullet = Instantiate(bulletPrefab, transform.position + transform.up / 3f - hitOffset, Quaternion.Euler(bulletForward));

        //Set bullet velocity
        bullet.GetComponentInChildren<BulletMovement>().SetVelocity(newVelocity);
    }

    private float CalculateAngle(Vector3 from, Vector3 to)
    {
        var angle = Vector3.SignedAngle(from, to, Vector3.forward);

        return angle;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Kill player, trigger gore 
        }

        if (collision.CompareTag("Bullet"))
        {
            HandleBullet(collision);
        }
    }

    private void HandleBullet(Collider2D bulletCollider)
    {
        var bullet = bulletCollider.transform.root.gameObject;

        var velocity = bullet.GetComponentInChildren<Rigidbody2D>().velocity;
        var bulletUp = bullet.transform.up;

        var targetPortals = GrabPortals();

        var point = bulletCollider.ClosestPoint(transform.position);
        var offset = transform.position - new Vector3(point.x, point.y, 0);
        offset /= transform.localScale.x;


        Destroy(bullet);

        foreach (var portal in targetPortals)
        {
            portal.TeleportBullet(velocity, bulletUp, transform.up, offset);
        }
    }

    private List<BulletPortal> GrabPortals()
    {
        PortalColor searchColor = PortalColor.Blue;

        switch (portalColor)
        {
            case PortalColor.Blue:
                searchColor = PortalColor.Orange;
                break;
            case PortalColor.Orange:
                searchColor = PortalColor.Blue;
                break;
            case PortalColor.Pink:
                searchColor = PortalColor.Green;
                break;
            case PortalColor.Green:
                searchColor = PortalColor.Pink;
                break;
        }

        var portals = FindObjectsOfType<BulletPortal>().Where(p => p.portalColor == searchColor).ToList();

        print(portals.Count);

        return portals;
    }

    private void TriggerGore()
    {
        //Trigger blood and gore on other portal
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position, transform.position + transform.up);
    }

    private void OnValidate()
    {
        if (!sprite)
        {
            sprite = GetComponent<SpriteRenderer>();
        }

        switch (portalColor)
        {
            case PortalColor.Blue:
                sprite.color = Color.blue;
                break;
            case PortalColor.Orange:
                sprite.color = Color.red;
                break;
            case PortalColor.Pink:
                sprite.color = Color.magenta;
                break;
            case PortalColor.Green:
                sprite.color = Color.green;
                break;
        }
    }
}
