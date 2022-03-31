using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    
    int score = 0;
    private void Start()
    {

    }
    public void AddPoints()
    {
        score++;
        text.text = "Score: " + score.ToString();
    }
    
    public void AddPointsPotion()
    {
        score += 10;
        text.text = "Score: " + score.ToString();
    }
}

