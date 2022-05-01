using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorOfObject : MonoBehaviour
{
    [SerializeField] private Material[] materials;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ColorChangeBullet")
        {
            gameObject.GetComponent<MeshRenderer>().material = materials[0];
            StartCoroutine(ChangeColorBack());
        }
    }

    IEnumerator ChangeColorBack()
    {
        yield return new WaitForSeconds(5);
        gameObject.GetComponent<MeshRenderer>().material = materials[1];
    }
}
