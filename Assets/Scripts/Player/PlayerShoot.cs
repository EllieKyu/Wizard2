using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerShoot : MonoBehaviour
{
    public GameObject Bullet;

    [SerializeField]
    private int bulletCount = 1;

    [SerializeField]
    [Range(0, 1f)]
    private float bulletSpawnOffset = 0.5f;

    Vector3 myTargetPosition;

    [SerializeField]
    private AudioClip[] shootSounds;

    [SerializeField]
    private AudioSource audioSource;

    InputAction shootAction;
    InputAction aimAction;

    private InputDevice currentDevice;

    private void Start()
    {
        shootAction = InputSystem.actions.FindAction("Shoot");
        aimAction = InputSystem.actions.FindAction("StickAim");
    }

    void Update()
    {
        if (shootAction.WasPressedThisFrame())
        {
            ShootBullet();
        }

        InputSystem.onActionChange += (obj, change) =>
        {
            if (change == InputActionChange.ActionPerformed)
            {
                var inputAction = (InputAction)obj;
                var lastControl = inputAction.activeControl;
                var lastDevice = lastControl.device;
                currentDevice = lastDevice;
            }
        };

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.R))
        {
            bulletCount++;
        }
#endif

    }

    private void ShootBullet()
    {
        Quaternion rotation = Quaternion.identity;
        Vector3 position = Vector3.zero;

        //if using MKB
        if (currentDevice.displayName == "Mouse" || currentDevice.displayName == "Keyboard")
        {
            //if you remove the top line aiming breaks, for no fucking reason. I hate programming
            myTargetPosition = Input.mousePosition;
            myTargetPosition = Camera.main.ScreenToWorldPoint(new Vector3(myTargetPosition.x, myTargetPosition.y, 0.0f));
        }

        else
        {
            var aim = aimAction.ReadValue<Vector2>().normalized;
            myTargetPosition = transform.position + new Vector3(aim.x, aim.y, 0);
        }

        var aimDirection = (myTargetPosition - transform.position).normalized;

        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90;
        rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        position = transform.position;
        position += aimDirection * bulletSpawnOffset;


        GameObject bulletObj = Instantiate(Bullet, position, rotation);
        bulletObj.GetComponentInChildren<BulletMovement>().InitBullet();

        bulletCount--;

        if (Timer.Instance)
        {
            Timer.Instance.AddTime();
        }

        audioSource.PlayOneShot(shootSounds[Random.Range(0, shootSounds.Length)]);

        if (currentDevice.displayName == "Mouse" || currentDevice.displayName == "Keyboard")
        {
            //nope
        }

        else
        {
            VibrationHelper.Instance.SmallVibration();
        }

    }

    public void AddBullet()
    {
        bulletCount++;
    }
}
