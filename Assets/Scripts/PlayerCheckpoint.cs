using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerCheckpoint : MonoBehaviour
{
    Vector3 spawnPosition;
    public Vector3 inicialPostion;

    [SerializeField] private bool lisbela;
    [SerializeField] private bool leleu;

    [SerializeField] private AudioSource checkAudioSource;
    [SerializeField] private AudioClip checkAudioClip;

    [SerializeField] private TextMeshProUGUI checkpointText;

    private bool canBeDetected;
    [SerializeField] private Image AIButton;
    [SerializeField] private Sprite[] AISprite;
    void Start()
    {
        canBeDetected = true;
        spawnPosition = inicialPostion;
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
            checkAudioSource.PlayOneShot(checkAudioClip);
            checkpointText.text = "Checkpoint";
            StartCoroutine(ClearText());
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

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Vapor"))
        {
            RespawnOnCheckPoint();
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
    public void CanBeDetedtedTurnOFF()
    {
        if (canBeDetected)
        {
            canBeDetected = false;
            AIButton.sprite = AISprite[0];
        }
        else
        {
            canBeDetected = true;
            AIButton.sprite = AISprite[1];
        }
    }

    IEnumerator ClearText()
    {
        yield return new WaitForSeconds(2f);
        checkpointText.text = "";
    }
}
