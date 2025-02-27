using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class AIAgentChasing : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform chaseTarget;

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(chaseTarget.position);
    }
}
