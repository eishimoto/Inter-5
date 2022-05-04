using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesController : MonoBehaviour
{
    [SerializeField] private GameObject particles;
    [SerializeField] private float partibleTime = 5f;
    private float timer = 0f;
    private void Start()
    {
        timer = partibleTime;
    }
    private void Update()
    {
        ParticleInterval();
    }
    public void ParticleInterval()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            particles.SetActive(true);
            timer = partibleTime;
        }
        Debug.Log(timer);
    }
}
