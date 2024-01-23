using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
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
                    Vector3 newDestination = transform.position + reculeDirection.normalized * reculDistance;

                    navMeshAgent.SetDestination(newDestination);

                    Collider[] hitColliders = Physics.OverlapSphere(transform.position, reculDistance + 5, LayerMask.GetMask("Obstacle"),QueryTriggerInteraction.Ignore);
                    foreach (Collider collider in hitColliders){
                        
                        if (collider.CompareTag("Obstacle")){
                            
                            gameObject.transform.position = newDestination + new Vector3(0, 0, -1);
                        }
                    }
                }
                else{
                    navMeshAgent.SetDestination(PlayerManager.instance.gameObject.transform.position);
                }
            }
        }
        else return;
    }
}
