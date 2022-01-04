using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update

    private float totalTime = 0;
    [SerializeField]
    private TextMeshProUGUI timerTMP;

    private static string KEY = "SpeedrunTime";
    private bool timerRunning = true;

    public static Timer Instance;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }

        if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level == 13)
        {
            timerRunning = false;
            SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
            HandleSpeedrun();
        }
    }

    public void AddTime()
    {
        totalTime += 1f;
    }

    private void HandleSpeedrun()
    {
        if (!PlayerPrefs.HasKey(KEY))
        {
            PlayerPrefs.SetFloat(KEY, totalTime);
        }

        if (PlayerPrefs.GetFloat(KEY) > totalTime)
        {
            PlayerPrefs.SetFloat(KEY, totalTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!timerRunning)
        {
            return;
        }

        totalTime += Time.deltaTime;
        int min = Mathf.FloorToInt(totalTime / 60);
        int sec = Mathf.FloorToInt(totalTime % 60);
        timerTMP.text = min.ToString("00") + ":" + sec.ToString("00");
    }
}
