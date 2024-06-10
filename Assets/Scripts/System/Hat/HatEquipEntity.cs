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

    public void GenerateEntity(HatDataEntry hat, bool unlocked)
    {
        hatId = hat.id;

        hatPicture.sprite = hat.sprite;
        hatName.text = hat.name;
        hatDescriptionField.text = unlocked ? hat.description : hat.lockedDescription;

        button.interactable = unlocked;
    }
}




