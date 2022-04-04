using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectionCollider : MonoBehaviour
{
    [SerializeField] private int sceneIndex;

    public Checkpoint Checkpoint;
    private void Awake()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
        }
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneIndex);
    }
}
