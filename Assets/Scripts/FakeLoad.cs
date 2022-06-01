using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeLoad : MonoBehaviour
{
    [SerializeField] private GameObject skip;
    [SerializeField] private float waitTime;
    void Start()
    {
        StartCoroutine(CloseLoad());
    }
    IEnumerator CloseLoad()
    {
        yield return new WaitForSeconds(waitTime);
        skip.SetActive(true);
        gameObject.SetActive(false);
    }
}
