using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveBehavior : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField] private Transform player;
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private Light enemyLight;
    private int waypointIndex;
    Vector3 target;

    [SerializeField] private float restTime;
    private float waitTime;

    public static bool isDetected = false;
    public bool follow;

    private void OnEnable()
    {
        UpdateDestination();
    }
    private void Start()
    {
        isDetected = false;
        follow = false;
        waitTime = restTime;
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
        else if (isDetected || follow)
        {
            agent.SetDestination(player.position);
            enemyLight.color = Color.red;
        }
    }

    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }
    
    void GetNextWaypoint()
    {
        waitTime -= Time.deltaTime;
        if (waitTime <= 0)
        {
            waypointIndex = (waypointIndex + 1) % waypoints.Count;
            waitTime = restTime;
        }
    }

}
