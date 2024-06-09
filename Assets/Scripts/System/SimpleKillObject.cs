using UnityEngine;

public class SimpleKillObject : MonoBehaviour
{
    public void KillObject(GameObject toDie)
    {
        Destroy(toDie);
    }
}
