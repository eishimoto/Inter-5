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
    public bool leleu;

    private void OnEnable()
    {
        UpdateDestination();
    }
    private void Start()
    {
        isDetected = false;
        follow = false;
        TextBox.canFollow = false;
        waitTime = restTime;
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }
    private void Update()
    {
        SetFollow();
        if (Vector3.Distance(transform.position, target) < 1f)
        {
            GetNextWaypoint();
            UpdateDestination();
        }
        if (isDetected)
        {
            agent.SetDestination(player.position);
            enemyLight.color = Color.red;
        }
        if(leleu)
        {
            if (follow)
            {
                agent.SetDestination(player.position);
            }
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

    public void SetFollow()
    {
        if (TextBox.canFollow)
        {
            follow = true;
        }
    }

}
