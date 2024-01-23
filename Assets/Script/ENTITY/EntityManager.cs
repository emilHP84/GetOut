using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    public static EntityManager instance;

    private void Awake(){
        instance = this;
    }



    public delegate void EntityHealHandler(int health, int maxHealth);
    public static event EntityHealHandler OnCheckHealth;
    public void OnEntityHealHandler(int health, int maxHealth){
        OnCheckHealth?.Invoke(health, maxHealth);
    }



    public delegate void EntityMoveHandler(float speed);
    public static event EntityMoveHandler OnEntityMove;
    public void OnEntityMoveHandler(float speed){
        OnEntityMove?.Invoke(speed);
    }



    public delegate void TakeDamageHandler(Entity entity, int damage);
    public static event TakeDamageHandler AsTakeDamage;
    public void AsTakeDamageHandler(Entity entity, int damage){ 
        AsTakeDamage?.Invoke(entity, damage);
    }
}

