using UnityEngine;
using TMPro;
using UnityEngine.UI;
using NUnit.Framework.Internal;
using System;
using System.Linq;

public class HatEquipEntity : MonoBehaviour
{
    public Image hatPicture;
    public TextMeshProUGUI hatName;
    public TextMeshProUGUI hatDescriptionField;
    public Button button;
    public HatID hatId;
    public HatMenuManager manager;

    public void GenerateEntity(HatDataEntry hat, bool unlocked, HatMenuManager manager)
    {
        hatId = hat.id;
        this.manager = manager;

        hatPicture.sprite = hat.sprite;
        hatName.text = hat.name;
        hatDescriptionField.text = unlocked ? hat.description : hat.lockedDescription;

        button.interactable = unlocked;
    }

    public void EquipHat()
    {
        manager.EquipHat(hatId);
    }
}




