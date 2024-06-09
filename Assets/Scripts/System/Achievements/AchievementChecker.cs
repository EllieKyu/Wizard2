using UnityEngine;

public class AchievementChecker : MonoBehaviour
{
    public static AchievementChecker Instance;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (!Instance)
        {
            Instance = this;
        }

        if (Instance != this)
        {
            Destroy(this);
        }
    }

    public void CheckAchievements()
    {
        var pps = PlayerPrefIO.Instance;
        var keys = pps.keys;

        var acManager = AchievementManager.Instance;

        //01 - Mute the music

        if (pps.HasKey(keys.MUSIC_VOLUME))
        {
            if (pps.GetFloat(keys.MUSIC_VOLUME) < 0.01f)
            {
                AchievementManager.Instance.RegisterAchievement(AchievementPointer.mutedTheMusic);
                print("Unlocked achievement: " + AchievementPointer.mutedTheMusic);
            }
        }

        //---
    }
}
