using UnityEngine;

/// <summary>
/// Ugly hack to make sure the overseer if present if we start a level on its own and not through the main menu.
/// </summary>
public class EditorBootstrap : MonoBehaviour
{
    public GameObject overseer;

    private void Awake()
    {
        var o = GameObject.Find("Overseer");

        if (!o)
        {
            Instantiate(overseer);
        }
    }
}
