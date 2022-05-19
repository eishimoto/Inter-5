using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCheckpoint : MonoBehaviour
{
    Vector3 spawnPosition;
    public Vector3 inicialPostion;

    [SerializeField] private bool lisbela;
    [SerializeField] private bool leleu;

    private bool canBeDetected;
    void Start()
    {
        canBeDetected = true;
        spawnPosition = inicialPostion;
        Debug.Log(spawnPosition.ToString());
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if(gameObject.transform.position.y < -10f)
        {
            if(lisbela)
            {
                Respawn();
            }
            if(leleu)
            {
                RespawnOnCheckPoint();
            }
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
            if (canBeDetected)
            {
                EnemyMoveBehavior.isDetected = true;
                Debug.Log(EnemyMoveBehavior.isDetected);
            }
        }

        if (other.gameObject.CompareTag("Respawn"))
        {
            if (lisbela)
            {
                if (canBeDetected)
                {
                    Respawn();
                }
            }
            if (leleu)
            {
                RespawnOnCheckPoint();
            }
        }
        
    }
    private void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        EnemyMoveBehavior.isDetected = false;
    }

    private void RespawnOnCheckPoint()
    {
        gameObject.SetActive(false);
        gameObject.transform.position = spawnPosition + new Vector3(0, 2f, 0);
        gameObject.SetActive(true);
    }

    public void CollisonWithPS()
    {
        Respawn();
    }

    public void CanBeDetedtedTurnOFF()
    {
        canBeDetected = false;
    }
}
