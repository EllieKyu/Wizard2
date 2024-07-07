using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuPrefab;

    [HideInInspector]
    public GameObject pauseMenuInstance;

    [HideInInspector]
    public GameObject canvas;

    private bool isPaused;
    public bool IsPaused => isPaused;

    public static PauseManager Instance;

    InputAction pauseAction;
    InputAction backAction;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }

        if (Instance != this)
        {
            print("Too many PauseManager, killing myself");
            Destroy(this);
        }
    }

    void Start()
    {
        pauseAction = InputSystem.actions.FindAction("Pause");
        backAction = InputSystem.actions.FindAction("MenuBack");

        if (!canvas)
        {
            var c = GameObject.Find("Canvas");

            if (c)
            {
                canvas = c;
            }

            else
            {
                print("Found no canvas");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseAction.WasPressedThisFrame())
        {
            HandlePauseAction();
        }

        if (isPaused && UiManager.Instance.NumberOfActivePanels == 0)
        {
            UnpauseGame();
        }
    }

    private void HandlePauseAction()
    {
        if (isPaused)
        {
            UnpauseGame();
        }

        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;

        ShowPausePanel();

        Time.timeScale = 0;
    }

    private void ShowPausePanel()
    {
        if (!pauseMenuInstance)
        {
            pauseMenuInstance = Instantiate(pauseMenuPrefab, canvas.transform);
        }

        UiManager.Instance.AddNewPanel(pauseMenuInstance);
    }

    public void UnpauseGame()
    {
        isPaused = false;

        UiManager.Instance.ForceCloseAllPanels();

        Time.timeScale = 1;
    }
}
