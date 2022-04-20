using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotColorChangeObject : MonoBehaviour
{
    [SerializeField] private GameObject colorChangeBullet;
    [SerializeField] private Transform colorChangeBulletSpawnPoint;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject bullet = Instantiate(colorChangeBullet, colorChangeBulletSpawnPoint.position, colorChangeBulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(colorChangeBulletSpawnPoint.forward * 1000);
            bullet.GetComponent<Rigidbody>().AddForce(colorChangeBulletSpawnPoint.up * 200);
        }
    }
}
