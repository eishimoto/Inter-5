using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirlceSync : MonoBehaviour
{
    public static int PosID = Shader.PropertyToID("_Player");
    public static int SizeID = Shader.PropertyToID("_Size");
    
    [SerializeField] private List<Material> _material;
    [SerializeField] private Camera Camera;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float radius = 1f;

    // Update is called once per frame
    void Update()
    {
        var dir = Camera.transform.position - transform.position;
        var ray = new Ray(transform.position, dir.normalized);

        if (Physics.Raycast(ray, 3000, layerMask))
        {
            foreach (var mat in _material)
            {
                mat.SetVector(PosID, transform.position);
                mat.SetFloat(SizeID, radius);
            }
        }
        else
        {
            foreach (var mat in _material)
            {
                mat.SetVector(PosID, Vector3.zero);
                mat.SetFloat(SizeID, 0);
            }
        }

        var view = Camera.WorldToViewportPoint(transform.position);
        foreach (var mat in _material)
        {
            mat.SetVector(PosID, view);
        }
    }
}
