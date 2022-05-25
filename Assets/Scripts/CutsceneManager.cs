using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private GameObject videoScene;
    [SerializeField] private GameObject AnimationScene;
    [SerializeField] private Animator Animator;

    void Start()
    {
        StartCoroutine(PlayVideo());
    }

    IEnumerator PlayVideo()
    {
        yield return new WaitForSeconds(22);
        videoScene.SetActive(false);
        if (videoScene.activeSelf == false)
        {
            AnimationScene.SetActive(true);
            Animator.SetTrigger("Start");
        }
    }

    IEnumerator LoadFirstLevel()
    {
        yield return new WaitForSeconds(50);
        SceneManager.LoadScene(1);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(1);
    }
}
