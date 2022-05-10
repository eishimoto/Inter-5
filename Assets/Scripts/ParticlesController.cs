using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesController : MonoBehaviour
{
    [SerializeField] private List<ParticleSystem> particles;
    [SerializeField] private float particleTime = 5f;
    [SerializeField] private AudioSource particleSound;
    private float timer = 0f;

    private void Start()
    {
        timer = particleTime;
    }
    private void Update()
    {
        ParticleInterval();
    }
    public void ParticleInterval()
    {
        timer -= Time.deltaTime;
        if (timer < particleTime/2)
        {
            foreach (var particleSystem in particles)
            {
                particleSystem.Stop();
                particleSound.Stop();
            }
        }
        if (timer <= 0)
        {
            foreach (var particleSystem in particles)
            {
                particleSystem.Play();
                particleSound.Play();
            }
            
            timer = particleTime;
        }
        Debug.Log(timer);
    }
}
