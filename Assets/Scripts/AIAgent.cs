using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class AIAgent : MonoBehaviour
{

    public NavMeshAgent navMeshAgent;
    public Transform chaseTarget;

    public List<Transform> waypoints;
    private int currentWaypoint = 0;

    private AIState aiState;

    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
        aiState = AIState.Wander;
    }

    void Update()
    {
        if(aiState == AIState.Wander)
        {
            if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                currentWaypoint = (currentWaypoint + 1) % waypoints.Count;
                navMeshAgent.SetDestination(waypoints[currentWaypoint].position);
            }
        }

        else if(aiState == AIState.Chase)
        {
            navMeshAgent.SetDestination(chaseTarget.position);
            if(Vector3.Distance(transform.position, chaseTarget.position) > 15)
            {
                aiState = AIState.Wander;
                navMeshAgent.SetDestination(waypoints[currentWaypoint].position);
            }
        }
    }

    public void HostileSpotted(Transform hostileTarget)
    {
        chaseTarget = hostileTarget;
        navMeshAgent.SetDestination(chaseTarget.position);
        aiState= AIState.Chase;
    }
}

public enum AIState
{
    Wander,
    Chase
}