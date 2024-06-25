using UnityEngine;
using System.Collections.Generic;

public class UiStack : MonoBehaviour
{
	public Stack<GameObject> panelStack = new Stack<GameObject>();

	public void AddPanel(GameObject newPanel)
	{
		DisableStack();
		panelStack.Push(newPanel);
	}

	public void RemovePanel()
	{
		if (panelStack.Count <= 0)
		{
			Debug.Log("The UI stack is empty", gameObject);
			return;
		}

		var g = panelStack.Pop();
		Destroy(g);

		ActivateTopStack();
	}

	private void ActivateTopStack()
	{
		if (panelStack.Count <= 0)
		{
			return;
		}

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
