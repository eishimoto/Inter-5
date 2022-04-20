using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorBullet : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DestroyGameObject());
    }

    IEnumerator DestroyGameObject()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
