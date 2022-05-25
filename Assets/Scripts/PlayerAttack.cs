using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _attackText;

    Ray ray;
    private void Start()
    {

    }

    void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 1, Color.red);
        DestroyWall();
    }

    void DestroyWall()
    {
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 2))
        {
            if (hit.transform.gameObject.CompareTag("wall"))
            {
                _attackText.text = "Attack";
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Destroy(hit.transform.gameObject);
                }
            }
            else
            {
                _attackText.text = "";
            }
        }
    }

}

