using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyCount : MonoBehaviour
{
    public GameObject keyPrompt;
    private AudioSource audioSource;
    [SerializeField] private AudioClip keyPickup;

    private bool playerIsClose;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerIsClose = false;
    }

    private void Update()
    {
        if(playerIsClose)
        {
            keyPrompt.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                audioSource.PlayOneShot(keyPickup);
                StartCoroutine(KeyPrompt());
            }
        }
        else if (!playerIsClose)
        {
            keyPrompt.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsClose = false;
        }
    }

    IEnumerator KeyPrompt()
    {
        yield return new WaitForSeconds(1f);
        UnlockDoor.keys++;
        gameObject.SetActive(false);
    }
}
