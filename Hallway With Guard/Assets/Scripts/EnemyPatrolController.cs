using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolController : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform[] patrolLocations;

    private int destPoint = 0; 

    void Start()
    {
        moveToNextLocation();
    }

    void Update()
    {
        if(!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            moveToNextLocation();
        }
    }

    void moveToNextLocation()
    {
        if(patrolLocations.Length == 0)
        {
            return;
        }

        agent.destination = patrolLocations[destPoint].position;

        destPoint = (destPoint + 1) % patrolLocations.Length;
    }
}
