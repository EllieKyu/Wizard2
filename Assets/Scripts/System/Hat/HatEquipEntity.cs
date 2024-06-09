using UnityEngine;
using TMPro;
using UnityEngine.UI;
using NUnit.Framework.Internal;
using System;
using System.Linq;

public class HatEquipEntity : MonoBehaviour
{
    public HatData hatData;
    public Image hatPicture;
    public TextMeshProUGUI hatName;
    public TextMeshProUGUI hatDescriptionField;
    public HatID hatID;

    private void Start()
    {
        GenerateEntity();
    }

    //Todo, inject hat id from controller

    private void GenerateEntity()
    {
        var element = hatData.Data.Find(h => h.id == hatID);

        hatPicture.sprite = element.sprite;
        hatName.text = element.name;
        hatDescriptionField.text = element.description;
    }
}




