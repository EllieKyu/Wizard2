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

    private void Awake()
    {
        coords.minX = min.position.x;
        coords.maxX = max.position.x;

        coords.minY = min.position.y;
        coords.maxY = max.position.y;
    }

    public CameraBoundCoordinates GetBounds()
    {
        return coords;
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
