using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HatData", menuName = "Scriptable Objects/HatData")]
public class HatData : ScriptableObject
{
    public List<HatDataEntry> Data = new List<HatDataEntry>();
}
