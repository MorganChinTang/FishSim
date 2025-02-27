using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class AIAgentWandering : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public float navRange = 10f;
    private float navTimer = 0f;

    void Start()
    {
        SetRandomDestination();
    }

    void Update()
    {
        navTimer += Time.deltaTime;

        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance || navTimer >= 5.0f)
        {
            SetRandomDestination();
            navTimer = 0f;
        }
    }

    void SetRandomDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * navRange;

        randomDirection += transform.position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, navRange, NavMesh.AllAreas))
        {
            navMeshAgent.SetDestination(hit.position);
        }
    }
}
