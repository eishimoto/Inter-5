using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    [SerializeField] RawImage rawImage;
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] GameObject blackscreen;
    [SerializeField] GameObject videoPlayerObject;
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
        blackscreen.SetActive(false);
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(22);
        videoPlayerObject.SetActive(true);
    }
}
