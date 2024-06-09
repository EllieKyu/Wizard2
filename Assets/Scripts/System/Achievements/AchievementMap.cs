using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AchievementMap", menuName = "Scriptable Objects/AchievementMap")]
public class AchievementMap : ScriptableObject
{
    public List<AchievementBind> binds = new List<AchievementBind>();
}

[System.Serializable]
public class AchievementBind
{
    public AchievementPointer achievementPointer;
    public string achievementId;
}