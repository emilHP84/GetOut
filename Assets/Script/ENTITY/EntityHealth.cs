using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EntityHealth : MonoBehaviour{
    private static EntityHealth instance;
    private Entity entity;

    private void Awake(){
        
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void OnEnable(){
            EntityManager.OnCheckHealth += CheckHealth;
            EntityManager.AsTakeDamage += TakeDamage;
    }

    private void OnDisable(){
        EntityManager.OnCheckHealth -= CheckHealth;
        EntityManager.AsTakeDamage -= TakeDamage;
    }

    private void Start(){
        entity = gameObject.GetComponent<Entity>();
    }

    void CheckHealth(int health, int maxHealth){
        if (health == 0){
            GameManager.IsDead();
        }
    }

    void TakeDamage(Entity entity, int damage){
        entity._stat.health -= damage;
        Debug.Log(damage);
    }
}
