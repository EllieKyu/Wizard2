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
    public Transform minX, maxX, minY, maxY;
    protected CameraBoundCoordinates coords;

    public bool DrawGismo = false;

    public Color gizmoColor;

    private void Awake()
    {
        coords.minX = minX.position.x;
        coords.maxX = maxX.position.x;

        coords.minY = minY.position.y;
        coords.maxY = maxY.position.y;
    }

    public CameraBoundCoordinates GetBounds()
    {
        return coords;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;

        Gizmos.DrawLine(new Vector3(minX.position.x, minY.position.y), new Vector3(minX.position.x, maxY.position.y));
        Gizmos.DrawLine(new Vector3(maxX.position.x, minY.position.y), new Vector3(maxX.position.x, maxY.position.y));

        Gizmos.DrawLine(new Vector3(minX.position.x, maxY.position.y), new Vector3(maxX.position.x, maxY.position.y));
        Gizmos.DrawLine(new Vector3(minX.position.x, minY.position.y), new Vector3(maxX.position.x, minY.position.y));
    }
}
