using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class VibrationHelper : MonoBehaviour
{
    public static VibrationHelper Instance;

    public float bigVibrationTime = 0.5f;
    public float bigVibrationPower = 0.15f;

    public float smallVibrationTime = 0.1f;
    public float smallVibrationPower = 0.1f;

    private void Start()
    {
        DontDestroyOnLoad(this);

        if (!Instance)
        {
            Instance = this;
        }

        if (Instance != this)
        {
            print("Too many PlayerCollisions, killing myself");
            Destroy(this);
        }
    }

    public void BigVibration()
    {
        if (!CanVibrate())
        {
            return;
        }

        StopAllCoroutines();
        StartCoroutine(BigVibrate());
    }

    public void SmallVibration()
    {
        if (!CanVibrate())
        {
            return;
        }

        StopAllCoroutines();
        StartCoroutine(SmallVibrate());
    }

    private bool CanVibrate()
    {
        var pps = PlayerPrefIO.Instance;
        return pps.GetBool(pps.keys.VIBRATION_ACTIVE, true);
    }

    private void ResetMotor()
    {
        Gamepad.current.SetMotorSpeeds(0, 0);
    }

    private IEnumerator SmallVibrate()
    {
        Gamepad.current.SetMotorSpeeds(0, smallVibrationPower);
        yield return new WaitForSeconds(smallVibrationTime);
        Gamepad.current.SetMotorSpeeds(0, 0);
    }

    private IEnumerator BigVibrate()
    {
        Gamepad.current.SetMotorSpeeds(bigVibrationPower, bigVibrationPower);
        yield return new WaitForSeconds(bigVibrationTime);
        Gamepad.current.SetMotorSpeeds(0, 0);
    }

    private void OnApplicationQuit()
    {
        ResetMotor();
    }
}
