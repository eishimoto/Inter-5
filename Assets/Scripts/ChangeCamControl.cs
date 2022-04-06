using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class ChangeCamControl : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera []cam;
    [SerializeField] private GameObject player;

    [SerializeField] private Image []arrows;
    [SerializeField] private Sprite arrowSprites;
    [SerializeField] private Sprite arrowSpritesblack;

    private void Start()
    {
        arrows[0].sprite = arrowSprites;
        arrows[1].sprite = arrowSpritesblack;
        arrows[2].sprite = arrowSpritesblack;
        arrows[3].sprite = arrowSpritesblack;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            cam[3].Priority = 1;
            cam[0].Priority = 0;
            cam[2].Priority = 0;
            cam[1].Priority = 0;
            arrows[0].sprite = arrowSpritesblack;
            arrows[1].sprite = arrowSpritesblack;
            arrows[2].sprite = arrowSpritesblack;
            arrows[3].sprite = arrowSprites;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            cam[3].Priority = 0;
            cam[0].Priority = 1;
            cam[2].Priority = 0;
            cam[1].Priority = 0;
            arrows[0].sprite = arrowSprites;
            arrows[1].sprite = arrowSpritesblack;
            arrows[2].sprite = arrowSpritesblack;
            arrows[3].sprite = arrowSpritesblack;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            cam[3].Priority = 0;
            cam[0].Priority = 0;
            cam[2].Priority = 1;
            cam[1].Priority = 0;
            arrows[0].sprite = arrowSpritesblack;
            arrows[1].sprite = arrowSpritesblack;
            arrows[2].sprite = arrowSprites;
            arrows[3].sprite = arrowSpritesblack;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            cam[3].Priority = 0;
            cam[0].Priority = 0;
            cam[2].Priority = 0;
            cam[1].Priority = 1;
            arrows[0].sprite = arrowSpritesblack;
            arrows[1].sprite = arrowSprites;
            arrows[2].sprite = arrowSpritesblack;
            arrows[3].sprite = arrowSpritesblack;
        }
    }
}
