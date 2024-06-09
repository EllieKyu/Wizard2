using Steamworks;
using System;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public enum AchievementPointer
{
    mutedTheMusic = 0
}

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager Instance;
    public AchievementMap achievementMap;
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

    void Start()
    {
        if (SteamManager.Initialized)
        {
            string name = SteamFriends.GetPersonaName();
            Debug.Log(name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            RegisterAchievement(AchievementPointer.mutedTheMusic);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            GetAchievementStatus();
        }
    }

    private void GetAchievementStatus()
    {
        bool hej = false;
        var v = SteamUserStats.GetAchievement(achievementMap.binds.Find(b => b.achievementPointer == AchievementPointer.mutedTheMusic).achievementId, out hej);

        print(achievementMap.binds.Find(b => b.achievementPointer == AchievementPointer.mutedTheMusic).achievementId + " is " + hej);

    }

    public void RegisterAchievement(AchievementPointer achievementPointer)
    {
        var achievement = achievementMap.binds.Find(b => b.achievementPointer == achievementPointer).achievementId;
        print(achievement);

        SteamUserStats.SetAchievement(achievement);
        SteamUserStats.StoreStats();
    }
}
