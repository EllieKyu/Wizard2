using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public GameObject audioOptions;
	public GameObject hatMenu;

	public Transform uiRoot;

	public void PlayGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void QuitGame()
	{
		Debug.Log("QUIT!");
		Application.Quit();
	}

	public void AudioOptions()
	{
		var panel = Instantiate(audioOptions, uiRoot);
		UiManager.Instance.AddNewPanel(panel);
	}

	public void HatMenu()
	{
		var panel = Instantiate(hatMenu, uiRoot);
		UiManager.Instance.AddNewPanel(panel);
	}
}
