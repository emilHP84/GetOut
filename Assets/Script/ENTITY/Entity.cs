using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public EntityManager entityManager;
    public STAT _stat;

    private void Awake(){
        _stat.health = _stat.maxHealth;
        ComboController.Attackmode = false;
    }

    void Start()
    {
        _stat.health = _stat.maxHealth;
    }

    
    void Update(){
        if (_stat.health > 0){
            entityManager.OnEntityHealHandler(_stat.health, _stat.maxHealth);
            if (CapacityManager.GrabCasted == false){
                entityManager.OnEntityMoveHandler(_stat.speed);
            }entityManager.AsAttackHandler(_stat.endurance);
        }
    }
}
