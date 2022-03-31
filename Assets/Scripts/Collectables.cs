using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    UpdateScore updateScore;

    private void Start()
    {
        updateScore = GameObject.Find("ScoreUpdate").GetComponent<UpdateScore>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            updateScore.AddPoints();
        }
    }
}
