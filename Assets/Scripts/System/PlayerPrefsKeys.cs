using UnityEngine;

[CreateAssetMenu(fileName = "PlayerPrefsKeys", menuName = "Scriptable Objects/PlayerPrefsKeys")]
public class PlayerPrefsKeys : ScriptableObject
{
    public readonly string MUTE_ALL = "AudioMuted";
    public readonly string MASTER_VOLUME = "MasterVolume";
    public readonly string MUSIC_VOLUME = "MusicVolume";
    public readonly string SFX_VOLUME = "SfxVolume";
}
