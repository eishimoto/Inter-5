using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Transform player;
    private NavMeshAgent meshAgent;

    private void Start()
    {
        meshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position,player.position) > 10)
        {
            meshAgent.speed = 10;
        }
        else
        {
            meshAgent.speed = 4;
        }
    }
}
