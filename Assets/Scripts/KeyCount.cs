using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyCount : MonoBehaviour
{
    public TextMeshProUGUI keyPrompt;
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
            keyPrompt.text = "Pressione F";

            if (Input.GetKeyDown(KeyCode.F))
            {
                audioSource.PlayOneShot(keyPickup);
                StartCoroutine(KeyPrompt());
            }
        }
        else if (!playerIsClose)
        {
            keyPrompt.text = "";
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

    private void OnDisable()
    {
        keyPrompt.text = "";
    }
}
