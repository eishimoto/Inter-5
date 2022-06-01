using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeLoad : MonoBehaviour
{
    [SerializeField] private GameObject skip;
    void Start()
    {
        StartCoroutine(CloseLoad());
    }
    IEnumerator CloseLoad()
    {
        yield return new WaitForSeconds(2f);
        skip.SetActive(true);
        gameObject.SetActive(false);
    }
}
