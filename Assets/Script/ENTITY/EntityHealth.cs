using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{
    private void OnEnable()
    {
        EntityManager.OnCheckHealth += CheckHealth;
        EntityManager.AsTakeDamage += TakeDamage;
    }
    private void OnDisable()
    {
        EntityManager.OnCheckHealth -= CheckHealth;
        EntityManager.AsTakeDamage -= TakeDamage;
    }

    void CheckHealth(int health, int maxHealth){
        if (health == 0){
            GameManager.IsDead();
        }
    }

    void TakeDamage(int damage){
        EntityManager.instance._stat.health -= damage;
    }
}
