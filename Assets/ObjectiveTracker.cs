using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveTracker : MonoBehaviour
{
    List<GameObject> PillarsRequired;
    List<GameObject> PillarsCompleted;

    private GateController myGateController;

    // Start is called before the first frame update
    void Start()
    {
        PillarsRequired = new List<GameObject>(GameObject.FindGameObjectsWithTag("Pillar"));
        PillarsCompleted = new List<GameObject>(PillarsRequired.Count);

        myGateController = FindObjectOfType<GateController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ObjectiveCompleted(GameObject Object)
    {
        GameObject foundObject = PillarsRequired.Find(x => x == Object);
        if (foundObject)
        {
            GameObject foundInPillarsCompleted = PillarsCompleted.Find(x => x == foundObject);
            if (!foundInPillarsCompleted)
            {
                PillarsCompleted.Add(foundObject);
            }
        }

        if (PillarsCompleted.Count == PillarsRequired.Count)
        {
            // Victory!
            myGateController.Unlock();
        }
    }
}
