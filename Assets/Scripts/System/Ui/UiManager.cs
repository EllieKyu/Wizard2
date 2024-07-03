using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;
    public UiStack uiStack;
    public EventSystem eventSystem;

    public InputAction menuBack;

    void Start()
    {
        if (!Instance)
        {
            Instance = this;
        }

        if (Instance != this)
        {
            print("Too many UiManagers, killing myself");
            Destroy(this);
        }

        SetupInputactions();

        if (!eventSystem)
        {
            eventSystem = EventSystem.current;
        }
    }

    private void SetupInputactions()
    {
        menuBack = InputSystem.actions.FindAction("MenuBack");
    }

    private void Update()
    {
        if (menuBack.WasPressedThisFrame())
        {
            CloseCurrentPanel();
        }
    }

    public void AddNewPanel(GameObject newPanel)
    {
        uiStack.AddPanel(newPanel);
        SetActiveButton(newPanel);
    }

    public void CloseCurrentPanel()
    {
        var newPanel = uiStack.RemovePanel();

        if (newPanel != null)
        {
            SetActiveButton(newPanel);
        }
    }

    private void SetActiveButton(GameObject panel)
    {
        var defButton = panel.GetComponentInChildren<DefaultButton>();

        if (defButton)
        {
            eventSystem.firstSelectedGameObject = defButton.GetButton();
            eventSystem.SetSelectedGameObject(defButton.GetButton());
            eventSystem.UpdateModules();
        }
    }
}
