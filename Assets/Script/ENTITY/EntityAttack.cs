using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EntityAttack : MonoBehaviour
{
    public float attackCooldown;

    public bool canAttack;
    public bool canHeal;
    private List<GameObject> entity = new List<GameObject>();
    float time;
    private void OnEnable(){
        EntityManager.AsAttack += DoDamage;
    }
    private void OnDisable(){
        EntityManager.AsAttack -= DoDamage;
    }

    private void Update(){
        time += Time.deltaTime;
    }
    void DoDamage(int damage){
        if(time >= attackCooldown) {
            PlayerManager.instance._stat.health -= gameObject.GetComponent<Entity>()._stat.endurance;
            time = 0;
        }
    }
    void DoHeal(int heal){
        if (time >= attackCooldown)
        {
            for (int j = 0; j < entity.Count; j++)
            {
                entity[j].GetComponent<Entity>()._stat.health += gameObject.GetComponent<Entity>()._stat.endurance;
            }    
        }
        time = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canAttack == true)
        {
            if (other.CompareTag("Player"))
            {
                DoDamage(gameObject.GetComponent<Entity>()._stat.endurance);
                Debug.Log("Test");
            }
        }

        if(canHeal == true)
        {
            if (other.CompareTag("Entity")){
                entity.Add(other.gameObject);
                DoHeal(gameObject.GetComponent<Entity>()._stat.endurance);
                Debug.Log("Test1");
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (canAttack == true)
        {
            if (other.CompareTag("Player"))
            {
                DoDamage(gameObject.GetComponent<Entity>()._stat.endurance);
                Debug.Log("Test");
            }
        }

        if (canHeal == true)
        {
            if (other.CompareTag("Entity"))
            {
                entity.Add(other.gameObject);
                DoHeal(gameObject.GetComponent<Entity>()._stat.endurance);
                Debug.Log("Test1");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        entity.Remove(other.gameObject);
    }

}
