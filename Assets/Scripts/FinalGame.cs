using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGame : MonoBehaviour
{
    [SerializeField] private GameObject finalpanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            finalpanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
