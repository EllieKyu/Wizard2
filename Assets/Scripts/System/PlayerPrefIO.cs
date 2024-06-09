using Steamworks;
using UnityEngine;

public class PlayerPrefIO : MonoBehaviour
{
    public static PlayerPrefIO Instance;
    public PlayerPrefsKeys keys;

    void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }

        if (Instance != this)
        {
            print("Too many PlayerPrefIO, killing myself");
            Destroy(this);
        }
    }

    public void WriteString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
        PlayerPrefs.Save();
    }

    public void WriteInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
        PlayerPrefs.Save();
    }

    public void WriteFloat(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
        PlayerPrefs.Save();
    }

    public void WriteBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
        PlayerPrefs.Save();
    }

    public string GetString(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return PlayerPrefs.GetString(key);
        }

        Debug.Log(key + " player pref is borked");
        return "Error";
    }

    public int GetInt(string key, int fallback = 0)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return PlayerPrefs.GetInt(key);
        }

        Debug.Log(key + " player pref is borked");
        return fallback;
    }

    public float GetFloat(string key, float fallback = 0)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return PlayerPrefs.GetFloat(key);
        }

        Debug.Log(key + " player pref is borked");
        return fallback;
    }

    public bool GetBool(string key, bool fallback = false)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return PlayerPrefs.GetInt(key) == 1 ? true : false;
        }

        Debug.Log(key + " player pref is borked");
        return fallback;
    }
}
