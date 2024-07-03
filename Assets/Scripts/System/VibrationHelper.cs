using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class VibrationHelper : MonoBehaviour
{
    public static VibrationHelper Instance;

    public float bigVibrationTime = 0.5f;
    public float bigVibrationPower = 0.15f;

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
        StopAllCoroutines();
        ResetMotor();
        StartCoroutine(BigVibrate());
    }

    private void ResetMotor()
    {
        Gamepad.current.SetMotorSpeeds(0, 0);
    }

    private IEnumerator BigVibrate()
    {
        print("bong");
        Gamepad.current.SetMotorSpeeds(bigVibrationPower, bigVibrationPower);
        yield return new WaitForSeconds(bigVibrationTime);
        Gamepad.current.SetMotorSpeeds(0, 0);
    }

    private void OnApplicationQuit()
    {
        ResetMotor();
    }
}
