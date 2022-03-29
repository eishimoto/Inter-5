using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float m_MoveSpeed = 3;
    [SerializeField] private float m_time = 3;

    DetectionCollider DetectionCollider;
    void Start()
    {
        StartCoroutine(WalkFoward());
    }
    IEnumerator WalkFoward()
    {
        float time = Time.time + m_time;
        while (time > Time.time)
        {
            Vector3 move = Vector3.forward * m_MoveSpeed * Time.deltaTime;
            transform.Translate(move);
           
            yield return null;
        }
        StartCoroutine(WalkRight());
    }
    IEnumerator WalkRight()
    {
        float time = Time.time + m_time;
        while (time > Time.time)
        {
            Vector3 move = Vector3.right * m_MoveSpeed * Time.deltaTime;
            transform.Translate(move);
            
            yield return null;
        }
        StartCoroutine(WalkDown());
    }
    IEnumerator WalkDown()
    {
        float time = Time.time + m_time;
        while (time > Time.time)
        {
            Vector3 move = Vector3.forward * -1 * m_MoveSpeed * Time.deltaTime;
            transform.Translate(move);
   
            yield return null;
        }
        StartCoroutine(WalkLeft());
    }
    IEnumerator WalkLeft()
    {
        float time = Time.time + m_time;
        while (time > Time.time)
        {
            Vector3 move = Vector3.left * m_MoveSpeed * Time.deltaTime;
            transform.Translate(move);

            yield return null;
        }
        StartCoroutine(WalkFoward());
    }
}
