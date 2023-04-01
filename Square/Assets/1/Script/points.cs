using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class points : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;

    void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
    }



    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
