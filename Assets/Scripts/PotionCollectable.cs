using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionCollectable : MonoBehaviour
{
    [SerializeField] Image Image;
    [SerializeField] Sprite Image2;

    UpdateScore updateScore;

    private void Start()
    {
        updateScore = GameObject.Find("ScoreUpdate").GetComponent<UpdateScore>();
    }

    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Image.sprite = Image2;
            Destroy(gameObject);
            updateScore.AddPointsPotion();
        }
    }
}
