using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private void OnEnable(){
        PlayerManager.OnCheckHealth += CheckHealth;
        PlayerManager.AsTakeDamage += TakeDamage;
    }
    private void OnDisable(){
        PlayerManager.OnCheckHealth -= CheckHealth;
        PlayerManager.AsTakeDamage -= TakeDamage;
    }

    void CheckHealth(int health, int maxHealth){
        if(health == 0){
            GameManager.IsDead();
        }
    }

    void TakeDamage(int damage){
        PlayerManager.instance._stat.health -= damage;
    }
}