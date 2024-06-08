using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;


public class CameraBoundCoordinates
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
}

public class CameraBounds : MonoBehaviour
{
    public Transform min, max;
    protected CameraBoundCoordinates coords;

    public bool drawGismo = false;

    public Color gizmoColor;

    public EdgeCollider2D edgeCollider2D;

    private void Start()
    {
        coords = new CameraBoundCoordinates();

        coords.minX = min.position.x;
        coords.maxX = max.position.x;

        coords.minY = min.position.y;
        coords.maxY = max.position.y;

        SetEdge();
    }

    private void SetEdge()
    {
        List<Vector2> path = new List<Vector2>() { new Vector2(coords.minX, coords.minY), new Vector2(coords.minX, coords.maxY), new Vector2(coords.maxX, coords.maxY), new Vector2(coords.maxX, coords.minY), new Vector2(coords.minX, coords.minY) };

        edgeCollider2D.SetPoints(path);
    }

    private void OnDrawGizmos()
    {
        if (!drawGismo)
        {
            return;
        }

        Gizmos.color = gizmoColor;

        Gizmos.DrawLine(new Vector3(min.position.x, min.position.y), new Vector3(min.position.x, max.position.y));
        Gizmos.DrawLine(new Vector3(max.position.x, min.position.y), new Vector3(max.position.x, max.position.y));

        Gizmos.DrawLine(new Vector3(min.position.x, max.position.y), new Vector3(max.position.x, max.position.y));
        Gizmos.DrawLine(new Vector3(min.position.x, min.position.y), new Vector3(max.position.x, min.position.y));
    }
}
