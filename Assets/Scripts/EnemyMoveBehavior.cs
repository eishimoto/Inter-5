using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveBehavior : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField] private Transform player;
    [SerializeField] private List<Transform> waypoints;
    private int waypointIndex;
    Vector3 target;

    public static bool isDetected = false;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, target) < 1f)
        {
            GetNextWaypoint();
            UpdateDestination();
        }
        if (isDetected)
        {
            agent.SetDestination(player.position);
        }
    }

    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }
    
    void GetNextWaypoint()
    {
        waypointIndex++;
        if (waypointIndex >= waypoints.Count)
        {
            waypointIndex = 0;
        }
    }

}
