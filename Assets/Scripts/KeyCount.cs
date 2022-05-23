using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyCount : MonoBehaviour
{
    public GameObject keyPrompt;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            keyPrompt.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                UnlockDoor.keys++;
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            keyPrompt.SetActive(false);
        }
    }
    private void OnDisable()
    {
        keyPrompt.SetActive(false);
    }
}
