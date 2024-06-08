using UnityEditor.PackageManager.UI;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public CameraBoundCoordinates coords;
    public Rigidbody2D rBody;
    public float forceStrength = 1;

    public static CameraFollow Instance;

    void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }

        if (Instance != this)
        {
            print("Too many CameraFollow, killing myself");
            Destroy(this);
        }

        AddCollider();
    }

    private void Start()
    {
        if (!target)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void AddCollider()
    {
        if (Camera.main == null) { Debug.LogError("Camera.main not found, failed to create edge colliders"); return; }

        var cam = Camera.main;
        if (!cam.orthographic) { Debug.LogError("Camera.main is not Orthographic, failed to create edge colliders"); return; }

        var bottomLeft = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        var topLeft = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane));
        var topRight = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane));
        var bottomRight = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane));

        // add or use existing EdgeCollider2D
        var edge = GetComponent<PolygonCollider2D>() == null ? gameObject.AddComponent<PolygonCollider2D>() : GetComponent<PolygonCollider2D>();

        var edgePoints = new[] { bottomLeft, topLeft, topRight, bottomRight, bottomLeft };
        edge.points = edgePoints;
    }

    private void Update()
    {
        var force = target.position - transform.position;
        force *= Time.deltaTime;
        force *= forceStrength;
        rBody.AddForce(force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("bing fucking bong");
    }

    public void UpdateTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
