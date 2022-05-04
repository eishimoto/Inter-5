using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCheckpoint : MonoBehaviour
{
    Vector3 spawnPosition;
    public Vector3 inicialPostion;
    void Start()
    {
        spawnPosition = inicialPostion;
        Debug.Log(spawnPosition.ToString());
        Cursor.lockState = CursorLockMode.Locked;
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
            spawnPosition = other.gameObject.transform.position + new Vector3(2, 0, 0);
            Debug.Log(spawnPosition.ToString());
        }
        if (other.gameObject.CompareTag("DetectionArea"))
        {
            EnemyMoveBehavior.isDetected = true;
            Debug.Log(EnemyMoveBehavior.isDetected);
        }

        if (other.gameObject.CompareTag("Respawn"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            EnemyMoveBehavior.isDetected = false;
        }
        
    }
    private void Respawn()
    {
        gameObject.SetActive(false);
        gameObject.transform.position = spawnPosition + new Vector3(0, 2f, 0);
        gameObject.SetActive(true);
    }

    public void CollisonWithPS()
    {
        Respawn();
    }
}
