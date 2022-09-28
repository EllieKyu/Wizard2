using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsatingText : MonoBehaviour
{
    public Transform target;

    private Vector3 origSize;

    public float sizeVariation = 0.25f;
    public float speed = 2f;

    private void Start()
    {
        origSize = target.localScale;
    }

    void Update()
    {
        var newsize = origSize + (origSize * sizeVariation * Mathf.Sin(Time.time * speed));

        target.transform.localScale = newsize;
    }
}
