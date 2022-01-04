using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuSpeedrun : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timerTMP;
    private static string KEY = "SpeedrunTime";
    void Start()
    {
        if (PlayerPrefs.HasKey(KEY))
        {
            var totalTime = PlayerPrefs.GetFloat(KEY);
            int min = Mathf.FloorToInt(totalTime / 60);
            int sec = Mathf.FloorToInt(totalTime % 60);
            timerTMP.text = min.ToString("00") + ":" + sec.ToString("00");
        }
    }
}
