using UnityEngine;

public enum HatID
{
    Basic = 0,
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
}
