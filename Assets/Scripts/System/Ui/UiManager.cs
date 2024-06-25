using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class UiManager : MonoBehaviour
{
	public static UiManager Instance;
	public UiStack uiStack;
	public EventSystem eventSystem;

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
	}

	private void Update()
	{
		if (menuBackAction.WasPressedThisFrame())
		{
			CloseCurrentPanel();
		}
	}

	public void AddNewPanel(GameObject newPanel)
	{
		uiStack.AddPanel(newPanel);

		var defButton = newPanel.GetComponentInChildren<DefaultButton>();

		if (defButton)
		{
			eventSystem.firstSelectedGameObject = defButton.GetButton();
		}
	}

	public void CloseCurrentPanel()
	{
		uiStack.RemovePanel();
	}
}
