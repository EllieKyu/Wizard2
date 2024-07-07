using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;
    public UiStack uiStack;
    public EventSystem eventSystem;

    public InputAction menuBack;

    private InputDevice currentDevice;

    private bool panelOpenedThisFrame = false;

    public int NumberOfActivePanels => uiStack.GetStackCount();

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

        if (InputDeciveHelper.Instance.IsUsingGamepad())
        {

            if (eventSystem.currentSelectedGameObject == null)
            {
                eventSystem.SetSelectedGameObject(eventSystem.firstSelectedGameObject);
            }
        }
    }

    public void AddNewPanel(GameObject newPanel)
    {
        uiStack.AddPanel(newPanel);
        SetActiveButton(newPanel);

        panelOpenedThisFrame = true;
        StartCoroutine(SetPanelOpenedBool());
    }

    IEnumerator SetPanelOpenedBool()
    {
        yield return new WaitForSeconds(0);
        panelOpenedThisFrame = false;
    }

    public void CloseCurrentPanel()
    {
        if (panelOpenedThisFrame)
        {
            return;
        }

        var newPanel = uiStack.RemovePanel();

        if (newPanel != null)
        {
            SetActiveButton(newPanel);
        }
    }

    public void ForceCloseAllPanels()
    {
        var returnPanel = uiStack.RemovePanel();

        if (returnPanel)
        {
            ForceCloseAllPanels();
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
