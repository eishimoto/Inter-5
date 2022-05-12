using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirlceSync : MonoBehaviour
{
    public static int PosID = Shader.PropertyToID("_Player");
    public static int SizeID = Shader.PropertyToID("_Size");
    
    [SerializeField] private Material _material;
    [SerializeField] private Camera Camera;
    [SerializeField] private LayerMask layerMask;

    // Update is called once per frame
    void Update()
    {
        var dir = Camera.transform.position - transform.position;
        var ray = new Ray(transform.position, dir.normalized);

        if (Physics.Raycast(ray, 3000, layerMask))
        {
            _material.SetFloat(SizeID, 0.3f);
        }
        else
        {
            _material.SetFloat(SizeID, 0);
        }

        var view = Camera.WorldToViewportPoint(transform.position);
        _material.SetVector(PosID, view);
    }
}
