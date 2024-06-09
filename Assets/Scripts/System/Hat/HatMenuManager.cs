using UnityEngine;

public class HatMenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseWindow()
    {
        AchievementChecker.Instance.CheckAchievements();
        Destroy(gameObject);
    }
}
