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
                    navMeshAgent.SetDestination(transform.position + reculeDirection.normalized * reculDistance);

                    RaycastHit hit;
                    if (Physics.Raycast(transform.position, new Vector3(0,0,1), out hit, reculDistance + 5)){
                        if (hit.collider.CompareTag("Obstacle")){
                            navMeshAgent.SetDestination(transform.position + reculeDirection.normalized * reculDistance + Vector3.left);
                        }
                    }
                    if (Physics.Raycast(transform.position, new Vector3(1,0,1), out hit, reculDistance + 5)){
                        if (hit.collider.CompareTag("Obstacle")){
                            navMeshAgent.SetDestination(transform.position + reculeDirection.normalized * reculDistance + Vector3.right);
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
