using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class ChangeCamControl : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] cam;

    [SerializeField] private Image[] arrows;
    [SerializeField] private Sprite arrowSprites;
    [SerializeField] private Sprite arrowSpritesblack;

    [SerializeField] private GameObject Lisbela;
    [SerializeField] private GameObject Cam;

    private AudioSource audioSource;
    [SerializeField] private AudioClip audioClips;

    private int currentCam;
    private int currentArrow;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        arrows[0].sprite = arrowSprites;
        arrows[1].sprite = arrowSpritesblack;
        arrows[2].sprite = arrowSpritesblack;
        arrows[3].sprite = arrowSpritesblack;
    }

    void Update()
    {
        ChangeCamWithOneKey();
        ChangeCamWithArrows();

        Cam.transform.position = Vector3.MoveTowards(Cam.transform.position, Lisbela.transform.position, 0.1f);
    }

    private void ChangeCamWithArrows()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            audioSource.PlayOneShot(audioClips);
            cam[3].gameObject.SetActive(false);
            cam[2].gameObject.SetActive(true);
            cam[1].gameObject.SetActive(false);
            cam[0].gameObject.SetActive(false);
            arrows[0].sprite = arrowSpritesblack;
            arrows[1].sprite = arrowSpritesblack;
            arrows[2].sprite = arrowSprites;
            arrows[3].sprite = arrowSpritesblack;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            audioSource.PlayOneShot(audioClips);
            cam[3].gameObject.SetActive(false);
            cam[2].gameObject.SetActive(false);
            cam[1].gameObject.SetActive(false);
            cam[0].gameObject.SetActive(true);
            arrows[0].sprite = arrowSprites;
            arrows[1].sprite = arrowSpritesblack;
            arrows[2].sprite = arrowSpritesblack;
            arrows[3].sprite = arrowSpritesblack;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            audioSource.PlayOneShot(audioClips);
            cam[3].gameObject.SetActive(true);
            cam[2].gameObject.SetActive(false);
            cam[1].gameObject.SetActive(false);
            cam[0].gameObject.SetActive(false);
            arrows[0].sprite = arrowSpritesblack;
            arrows[1].sprite = arrowSpritesblack;
            arrows[2].sprite = arrowSpritesblack;
            arrows[3].sprite = arrowSprites;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            audioSource.PlayOneShot(audioClips);
            cam[3].gameObject.SetActive(false);
            cam[2].gameObject.SetActive(false);
            cam[1].gameObject.SetActive(true);
            cam[0].gameObject.SetActive(false);
            arrows[0].sprite = arrowSpritesblack;
            arrows[1].sprite = arrowSprites;
            arrows[2].sprite = arrowSpritesblack;
            arrows[3].sprite = arrowSpritesblack;
        }
    }
    
    private void ChangeCamWithOneKey()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            audioSource.PlayOneShot(audioClips);
            currentCam++;
            if (currentCam < cam.Length)
            {
                cam[currentCam - 1].gameObject.SetActive(false);
                cam[currentCam].gameObject.SetActive(true);
            }
            else
            {
                cam[currentCam - 1].gameObject.SetActive(false);
                currentCam = 0;
                cam[currentCam].gameObject.SetActive(true);
            }

            foreach (var item in arrows)
            {
                item.sprite = arrowSpritesblack;
            }
            currentArrow++;
            if(currentArrow < arrows.Length)
            {
                arrows[currentArrow - 1].sprite = arrowSpritesblack;
                arrows[currentArrow].sprite = arrowSprites;
            }
            else
            {
                arrows[currentArrow - 1].sprite = arrowSpritesblack;
                currentArrow = 0;
                arrows[currentArrow].sprite = arrowSprites;
            }
        }
    }

  
}
