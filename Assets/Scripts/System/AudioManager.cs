using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicPlayer;
    public AudioSource sfxPlayer;

    public static AudioManager Instance;

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
    }

    public void PlayMusic(AudioClip toPlay)
    {
        musicPlayer.PlayOneShot(toPlay);
    }
}
