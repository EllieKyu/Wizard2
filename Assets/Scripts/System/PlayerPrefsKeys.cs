using UnityEngine;

[CreateAssetMenu(fileName = "PlayerPrefsKeys", menuName = "Scriptable Objects/PlayerPrefsKeys")]
public class PlayerPrefsKeys : ScriptableObject
{
    //Sound options
    public readonly string MUTE_ALL = "AudioMuted";
    public readonly string MASTER_VOLUME = "MasterVolume";
    public readonly string MUSIC_VOLUME = "MusicVolume";
    public readonly string SFX_VOLUME = "SfxVolume";

    //Hats
    public readonly string EQUIPPED_HAT = "CurrentHat";
}
