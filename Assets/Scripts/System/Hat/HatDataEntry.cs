using UnityEngine;

public enum HatID
{
    EmptyState = 0,
    Basic,
    TripleThreat
}

[System.Serializable]
public class HatDataEntry
{
    public HatID id;
    public string name;
    public string description;
    public string lockedDescription;
    public Sprite sprite;
    public Sprite lockedSprite;
    public bool available;
}
