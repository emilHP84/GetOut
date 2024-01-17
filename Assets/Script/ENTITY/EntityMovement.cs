using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class EntityMovement : MonoBehaviour
{ 
    public NavMeshAgent navMeshAgent;
    public bool isCacPNJ;

    private float followDistance = 30f;
    private float reculDistance = 15f; 

    private void OnEnable(){
        EntityManager.OnEntityMove += Moving;
    }
    private void OnDisable(){
        EntityManager.OnEntityMove -= Moving;
    }

    private void Start(){
        navMeshAgent = GetComponent<NavMeshAgent>();
        
    }


    void Moving( float speed){
        navMeshAgent.speed = speed;
        if (PlayerManager.instance.gameObject != null){
            if (isCacPNJ == true){
                navMeshAgent.SetDestination(PlayerManager.instance.gameObject.transform.position);
            }
            else{
                float playerDistance = Vector3.Distance(transform.position, PlayerManager.instance.gameObject.transform.position);
                if (playerDistance < reculDistance)
                {
                    Vector3 reculeDirection = transform.position - PlayerManager.instance.gameObject.transform.position;
                    navMeshAgent.SetDestination(transform.position + reculeDirection.normalized * reculDistance);
                }
                else if (playerDistance < followDistance){
                    navMeshAgent.SetDestination(PlayerManager.instance.gameObject.transform.position);
                }
            }
        }
        else return;
    }
}
