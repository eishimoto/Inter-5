using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleVapor : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(Disable());
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(4f);
        gameObject.SetActive(false);
    }
}
