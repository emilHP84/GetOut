using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = " Stat", menuName = "StatCapacity")]
public class CapacitySTAT : ScriptableObject{
    
    [Header(" damage/bonus amount")]
    public int amount;
    [Header("time")]
    public float spellCast;
    public float spellduring;
    [Header("move")]
    public float speedDiminusion;
    public float sensitivityDiminution;
}
