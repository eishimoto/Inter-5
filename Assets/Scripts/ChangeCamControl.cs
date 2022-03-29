using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeCamControl : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera []cam;
    [SerializeField] private GameObject player;
    int camIndex;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            cam[3].Priority = 1;
            cam[0].Priority = 0;
            cam[2].Priority = 0;
            cam[1].Priority = 0;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            cam[3].Priority = 0;
            cam[0].Priority = 1;
            cam[2].Priority = 0;
            cam[1].Priority = 0;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            cam[3].Priority = 0;
            cam[0].Priority = 0;
            cam[2].Priority = 1;
            cam[1].Priority = 0;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            cam[3].Priority = 0;
            cam[0].Priority = 0;
            cam[2].Priority = 0;
            cam[1].Priority = 1;
        }
    }
}
