using System;
using UnityEngine;

public class HatManager : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public HatData hatData;

    private void Start()
    {
        if (PlayerPrefHelper.Instance)
        {
            var hat = FetchHatSprite();
            ApplyHat(hat);
        }
    }

    private Sprite FetchHatSprite()
    {
        return hatData.Data.Find(d => d.id == PlayerPrefHelper.Instance.FetchEquippedHat()).sprite;
    }

    private void ApplyHat(Sprite hat)
    {
        spriteRenderer.sprite = hat;
    }
}
