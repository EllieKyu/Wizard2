using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicPlayer;
    public AudioSource sfxPlayer;
    public AudioMixer mainMix;

    public float minVolume = -80f;
    public float maxVolume = 0f;

    public static AudioManager Instance;

    public PlayerPrefsKeys playerPrefsKeys;

    void Start()
    {
        if (!Instance)
        {
            Instance = this;
        }

        if (Instance != this)
        {
            print("Too many audiosources, killing myself");
            Destroy(this);
        }

        SetAudioLevels();
    }

    public void SetAudioLevels()
    {
        if (PlayerPrefs.HasKey(playerPrefsKeys.MUSIC_VOLUME))
        {
            var vol = PlayerPrefs.GetFloat(playerPrefsKeys.MUSIC_VOLUME);
            var decibel = Mathf.Log10(vol) * 20;
            mainMix.SetFloat("MusicVolume", decibel);
        }

        if (PlayerPrefs.HasKey(playerPrefsKeys.SFX_VOLUME))
        {
            var vol = PlayerPrefs.GetFloat(playerPrefsKeys.SFX_VOLUME);
            var decibel = Mathf.Log10(vol) * 20;
            mainMix.SetFloat("SfxVolume", decibel);
        }

        if (PlayerPrefs.HasKey(playerPrefsKeys.MASTER_VOLUME))
        {
            var vol = PlayerPrefs.GetFloat(playerPrefsKeys.MASTER_VOLUME);
            var decibel = Mathf.Log10(vol) * 20;
            mainMix.SetFloat("MasterVolume", decibel);
        }
    }

    //Secret logarithmic sauce 
    //Mathf.Log10(sliderValue) * 20

    public void PlayMusic(AudioClip toPlay)
    {
        musicPlayer.PlayOneShot(toPlay);
    }
}
