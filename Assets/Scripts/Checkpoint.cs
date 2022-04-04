using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    Vector3 lastPosition;
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            lastPosition = gameObject.transform.position;
            Debug.Log(lastPosition.ToString());
            Debug.Log(gameObject.transform.position.ToString());
        }

        if(other.gameObject.CompareTag("Respawn"))
        {
            StartCoroutine(loadLastPostition());      
        }
    }

    IEnumerator loadLastPostition()
    {
        yield return new WaitForSeconds(.5f);
        gameObject.transform.position = lastPosition;
        Debug.Log("hit");
    }
}
