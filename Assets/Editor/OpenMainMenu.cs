using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class OpenMainMenu : EditorWindow
{
    [MenuItem("Wizard/OpenMain %#o")]
    public static void OpenMain()
    {
        //Open the Scene in the Editor (do not enter Play Mode)
        EditorSceneManager.OpenScene("Assets/scenes/MainMenu.unity");
    }
}