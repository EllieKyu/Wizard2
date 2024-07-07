using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void ResumeGame()
    {
        PauseManager.Instance.UnpauseGame();
    }
}
