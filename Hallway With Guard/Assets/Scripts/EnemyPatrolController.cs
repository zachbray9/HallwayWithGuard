using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;

    public Transform[] patrolLocations;

    public float maxRange;
    private int destPoint = 0; 



    void Start()
    {
        moveToNextLocation();
    }



    void Update()
    {
        
        float currentDistance = Vector3.Distance(transform.position, player.position);

        if(checkIfPlayerInSight() && isInLineOfSight())
        {
            if(currentDistance < maxRange)
            {
                //chicken chases player
                agent.SetDestination(player.position);
                //transform.LookAt(player);

                transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));

                agent.speed = 10f;
            }
        }
        else
        {
            if(!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                agent.speed = 5f;
                moveToNextLocation();
            }
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



    bool checkIfPlayerInSight()
    {

        Vector3 directionOfPlayer = transform.position - player.position;
        float angle = Vector3.Angle(transform.forward, directionOfPlayer);

        if(Mathf.Abs(angle) > 90 && Mathf.Abs(angle) < 270)
        {
            //Debug.DrawLine(transform.position, player.position, Color.red);
            return true;
        }

        return false;

    }



    bool isInLineOfSight()
    {

        RaycastHit hit;
        Vector3 directionOfPlayer = player.position - transform.position;

        if(Physics.Raycast(transform.position, directionOfPlayer, out hit, 50000f))
        {
            if(hit.transform.name == "First Person Player")
            {
                Debug.DrawLine(transform.position, player.position, Color.green);
                return true;
            }
        }

        return false;

    }

}
