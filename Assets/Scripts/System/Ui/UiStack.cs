using UnityEngine;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;

public class UiStack : MonoBehaviour
{
    public Stack<GameObject> panelStack = new Stack<GameObject>();

    private void Awake()
    {
        var find = FindFirstObjectByType<DefaultButton>();

        if (!find)
        {
            return;
        }

        panelStack.Push(find.gameObject);
    }

    public void AddPanel(GameObject newPanel)
    {
        DisableStack();
        panelStack.Push(newPanel);
        newPanel.SetActive(true);
    }

    public GameObject RemovePanel()
    {
        if (panelStack.Count == 0)
        {
            Debug.Log("The UI stack is empty", gameObject);
            return null;
        }

        var g = panelStack.Peek();

        if (g.GetComponentInChildren<KeepUIActive>())
        {
            return null;
        }

        else
        {
            g.SetActive(false);
            panelStack.Pop();

            if (panelStack.Count == 0)
            {
                Debug.Log("The UI stack is empty", gameObject);
                return null;
            }

            ActivateTopStack();
            return panelStack.Peek();
        }
    }

    private void ActivateTopStack()
    {
        var g = panelStack.Peek();
        g.SetActive(true);
    }

    private void DisableStack()
    {
        if (panelStack.Count > 0)
        {
            foreach (var panel in panelStack)
            {
                panel.SetActive(false);
            }
        }
    }

    public int GetStackCount()
    {
        return panelStack.Count;
    }
}
