using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesTest : MonoBehaviour
{
    ParticleSystem ps;
    [SerializeField] private PlayerCheckpoint playerCheckpoint;
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Player")
        {
            playerCheckpoint.CollisonWithPS();
        }
    }
}
