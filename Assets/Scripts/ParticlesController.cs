using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesController : MonoBehaviour
{
    [SerializeField] private List<ParticleSystem> particles;
    [SerializeField] private float particleTime = 5f;
    private AudioSource particleSound;
    private float timer = 0f;

    private bool playerIsClose;

    private void Start()
    {
        playerIsClose = false;
        timer = particleTime;
        particleSound = GetComponent<AudioSource>();
    }
    private void Update()
    {
        ParticleInterval();
    }
    public void ParticleInterval()
    {
        timer -= Time.deltaTime;
        if (timer < particleTime / 2)
        {
            foreach (var particleSystem in particles)
            {
                particleSystem.Stop();
                
                if (!playerIsClose)
                {
                    particleSound.Stop();
                }
            }
        }
        if (timer <= 0)
        {
            foreach (var particleSystem in particles)
            {
                particleSystem.Play();
                if (playerIsClose)
                {
                    particleSound.Play();
                }
            }

            timer = particleTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
        }
    }
}
