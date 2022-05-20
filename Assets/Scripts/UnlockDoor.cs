using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    [SerializeField] private GameObject door;

    public static int keys;
    void Start()
    {
        keys = 0;
    }

    void Update()
    {
        Debug.Log(keys);
        if (keys == 4)
        {
            door.SetActive(false);
        }
    }
}
