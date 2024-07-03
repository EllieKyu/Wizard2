using System;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider masterSlider;
    public Toggle vibrationToggle;


    private void Start()
    {
        SetupSliders();
        SetupToggle();
    }

    private void SetupToggle()
    {
        var pps = PlayerPrefIO.Instance;

        var vibration = pps.GetBool(pps.keys.VIBRATION_ACTIVE, true);
        vibrationToggle.isOn = vibration;
    }

    private void SetupSliders()
    {
        var pps = PlayerPrefIO.Instance;

        var musicValue = pps.GetFloat(pps.keys.MUSIC_VOLUME, 1);
        musicSlider.value = musicValue;

        var sfxValue = pps.GetFloat(pps.keys.SFX_VOLUME, 1);
        sfxSlider.value = sfxValue;

        var masterValue = pps.GetFloat(pps.keys.MASTER_VOLUME, 1);
        masterSlider.value = masterValue;
    }

    public void SetMusicLevel(float value)
    {
        var pps = PlayerPrefIO.Instance;
        pps.WriteFloat(pps.keys.MUSIC_VOLUME, value);

        var am = AudioManager.Instance;
        if (am)
        {
            am.SetAudioLevels();
        }
    }

    public void SetSfxLevel(float value)
    {
        var pps = PlayerPrefIO.Instance;
        pps.WriteFloat(pps.keys.SFX_VOLUME, value);

        var am = AudioManager.Instance;
        if (am)
        {
            am.SetAudioLevels();
        }
    }

    public void SetMasterLevel(float value)
    {
        var pps = PlayerPrefIO.Instance;
        pps.WriteFloat(pps.keys.MASTER_VOLUME, value);

        var am = AudioManager.Instance;
        if (am)
        {
            am.SetAudioLevels();
        }
    }

    public void SetVibration(bool vibration)
    {
        var pps = PlayerPrefIO.Instance;
        pps.WriteBool(pps.keys.VIBRATION_ACTIVE, vibration);

        if (vibration)
        {
            VibrationHelper.Instance.SmallVibration();
        }
    }

    public void CloseWindow()
    {
        AchievementChecker.Instance.CheckAchievements();
        Destroy(gameObject);
    }
}
