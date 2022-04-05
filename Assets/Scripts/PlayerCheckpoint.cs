using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    public GameObject checkpoint;
    Vector3 spawnPosition;
    
    void Start()
    {
        spawnPosition = gameObject.transform.position;
        Debug.Log(spawnPosition.ToString());
    }

    void Update()
    {
        if(gameObject.transform.position.y < -10f)
        {
            gameObject.transform.position = spawnPosition + new Vector3(2f, 5f, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Checkpoint"))
        {
            spawnPosition = checkpoint.transform.position;
            Debug.Log(spawnPosition.ToString());
        }
    }
}
