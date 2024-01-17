using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    public static EntityManager instance;
    public STAT _stat;



    private void Awake()
    {
        instance = this;
        _stat.health = _stat.maxHealth;
    }

    private void Update()
    {
        OnEntityHealHandler(_stat.health, _stat.maxHealth);
        OnEntityMoveHandler(_stat.speed); 
    }



    public delegate void EntityHealHandler(int health, int maxHealth);
    public static event EntityHealHandler OnCheckHealth;
    public void OnEntityHealHandler(int health, int maxHealth)
    {
        OnCheckHealth?.Invoke(health, maxHealth);
    }



    public delegate void EntityMoveHandler(float speed);
    public static event EntityMoveHandler OnEntityMove;
    public void OnEntityMoveHandler(float speed)
    {
        speed = _stat.speed;
        OnEntityMove?.Invoke(speed);
    }



    public delegate void TakeDamageHandler(int damage);
    public static event TakeDamageHandler AsTakeDamage;
    public static void AsTakeDamageHandler(int damage)
    {
        damage = CapacityManager.damageCap;
        AsTakeDamage?.Invoke(damage);
    }
}

