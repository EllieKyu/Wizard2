using UnityEngine;

public class HatManager : MonoBehaviour
{
    public static HatManager Instance;
    private Sprite equippedHat;

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

    private void FetchHatSprite()
    {
        //Fetch player pref
        //Fetch player hat data sprite
    }

    private void ApplyHatToPlayer()
    {
        //Replace sprite on player
    }

    public void SetNewHat(HatID newHat)
    {
        //Save player pref
    }
}
