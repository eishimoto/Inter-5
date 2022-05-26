using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionCollectable : MonoBehaviour
{
    [SerializeField] Image Image;
    [SerializeField] Sprite Image2;

    [SerializeField] private AudioSource potionAudioSource;
    [SerializeField] private AudioClip potionAudioClip;

    UpdateScore updateScore;

    private void Start()
    {
    }
    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Image.sprite = Image2;
            potionAudioSource.PlayOneShot(potionAudioClip);
            Destroy(gameObject);
        }
    }
}
