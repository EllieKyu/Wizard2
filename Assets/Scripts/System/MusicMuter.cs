using UnityEngine;

public class MusicMuter : MonoBehaviour
{

    private const string MUTE_KEY = "MusicMuted";
    private bool musicMuted = false;

    public AudioSource audioSource;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(MUTE_KEY))
        {
            musicMuted = PlayerPrefs.GetInt(MUTE_KEY) == 0 ? false : true;
            SetMuteStatus();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            musicMuted = !musicMuted;
            SetMuteStatus();
        }
    }

    private void SetMuteStatus()
    {
        audioSource.mute = musicMuted;
        PlayerPrefs.SetInt(MUTE_KEY, musicMuted ? 1 : 0);
    }
}
