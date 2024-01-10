using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = " Stat", menuName = "Stat")]
public class STAT : ScriptableObject {
    public int maxHealth;
    public int health;
    public float endurance;
    public float speed;
    public float turnSpeed;
}
