using System;
using UnityEngine;

public class PlayerPrefHelper : MonoBehaviour
{
    public static PlayerPrefHelper Instance;
    public PlayerPrefsKeys keys;

    void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }

        if (Instance != this)
        {
            print("Too many PlayerPrefFetcher, killing myself");
            Destroy(this);
        }

        DontDestroyOnLoad(this);
    }


    public HatID FetchEquippedHat()
    {
        var prefsIO = PlayerPrefIO.Instance;

        var stringId = prefsIO.GetString(prefsIO.keys.EQUIPPED_HAT, HatID.Basic.ToString());

        return (HatID)Enum.Parse(typeof(HatID), stringId);
    }

    public void SetEquippedHat(HatID hat)
    {
        var prefsIO = PlayerPrefIO.Instance;
        prefsIO.WriteString(prefsIO.keys.EQUIPPED_HAT, hat.ToString());
    }

}
