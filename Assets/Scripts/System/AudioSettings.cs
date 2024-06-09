using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider masterSlider;


    private void Start()
    {
        SetupSliders();
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
}
