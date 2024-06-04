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

/*
public class ObjectSwitcheroo : EditorWindow
{
    public Object obj1;
    public GameObject obj2;

    public GameObject newObject;

    protected bool destroyObject;

    [MenuItem("Window/Dogges Utility/LodSwitcher")]
    public static void ShowWindow()
    {
        GetWindow<ObjectSwitcheroo>("LodSwitcher");
    }
*/