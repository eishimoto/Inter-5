using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    [SerializeField] RawImage rawImage;
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] AudioSource audioSource;
    
    void Start()
    {
        StartCoroutine(PlayVideoCoroutine());
    }

    IEnumerator PlayVideoCoroutine()
    {
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
        audioSource.Play();
    }
}
