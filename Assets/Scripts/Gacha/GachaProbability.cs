using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GachaProbability", menuName = "Scriptable Object/GachaProbability", order = int.MaxValue)]
public class GachaProbability : ScriptableObject
{
    [SerializeField]
    public float[] probability;

}
