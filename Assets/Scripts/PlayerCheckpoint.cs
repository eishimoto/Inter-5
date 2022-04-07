using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    Vector3 spawnPosition;
    
    void Start()
    {
        spawnPosition = new Vector3(0,2,0);
        Debug.Log(spawnPosition.ToString());
    }

    void Update()
    {
        if(gameObject.transform.position.y < -10f)
        {
            Respawn();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Checkpoint"))
        {
            spawnPosition = other.gameObject.transform.position;
            Debug.Log(spawnPosition.ToString());
        }

        if (other.gameObject.CompareTag("Respawn"))
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        gameObject.SetActive(false);
        gameObject.transform.position = spawnPosition + new Vector3(2f, 5f, 0);
        gameObject.SetActive(true);
    }
}
