using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    UpdateScore updateScore;

    [SerializeField] private AudioSource collectSound;
    [SerializeField] private AudioClip collectClip;
    private void Start()
    {
        updateScore = GameObject.Find("ScoreUpdate").GetComponent<UpdateScore>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            collectSound.PlayOneShot(collectClip);
            Destroy(gameObject);
            updateScore.AddPoints();
        }
    }
}
