using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public CameraBoundCoordinates coords;

    void Start()
    {
        //if no camera bounds found, nuke self


        //else, fetch min max.
        //calc own bounds
        //fetch target (player)

    }

    // Update is called once per frame
    void Update()
    {
        //move
        //handle "collision"
    }
}
