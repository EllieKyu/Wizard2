using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HatMenuManager : MonoBehaviour
{
    public List<HatEquipEntity> entries = new List<HatEquipEntity>();
    public Button prevButton;
    public Button nextButton;


    public HatData hatData;
    public int currentPage = 0;
    public int maxPages = 1;
    public List<HatDataEntry> availableHats;
    private HatDataEntry emptyHat;



    void Start()
    {
        InitHats();
        SetMaxPages();
        SetupEntries();
        SetupArrows();
    }

    private void SetupArrows()
    {
        SetPreviousPageArrowEnabled();
        SetNextPageArrowEnabled();
    }

    private void InitHats()
    {
        availableHats = hatData.Data.FindAll(d => d.available);
        emptyHat = hatData.Data.Find(d => d.id == HatID.EmptyState);
    }

    private void SetMaxPages()
    {
        maxPages = Mathf.CeilToInt((float)availableHats.Count / entries.Count);
    }

    private void SetupEntries()
    {
        for (int pagePosition = 0; pagePosition < entries.Count; pagePosition++)
        {
            var currentIndex = currentPage * entries.Count + pagePosition;
            var currentEntry = entries[pagePosition];

            if (currentIndex >= availableHats.Count)
            {
                SetupEntry(currentEntry, emptyHat, false);
            }

            else
            {
                //find if unlocked
                var unlocked = true;
                SetupEntry(currentEntry, availableHats[currentIndex], unlocked);
            }
        }
    }

    private void SetupEntry(HatEquipEntity uiEntity, HatDataEntry hat, bool available)
    {
        uiEntity.GenerateEntity(hat, available);
    }

    public void NextPage()
    {
        //go to next page
    }

    public void PrevPage()
    {
        //go to previous page
    }

    public void SetPreviousPageArrowEnabled()
    {
        prevButton.interactable = currentPage > 0;
    }

    private void SetNextPageArrowEnabled()
    {
        nextButton.interactable = maxPages > currentPage + 1;
    }

    public void CloseWindow()
    {
        AchievementChecker.Instance.CheckAchievements();
        Destroy(gameObject);
    }

    public void EquipHat(HatID newHat)
    {
        //save hat
    }
}
