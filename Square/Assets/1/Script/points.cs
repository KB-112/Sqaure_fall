using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class points : MonoBehaviour
{
  

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScore;


    public int highScore;
    public int score;

    void Start()
    {
        // Load the saved high score from PlayerPrefs
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        bestScore.text = highScore.ToString(); // update the best score text with the saved high score
    }

    public void UpdateScore()
    {
        score++;

        // Update the score text
        scoreText.text = score.ToString();

        if (score > highScore)
        {
            highScore = score;

            // Save the new high score to PlayerPrefs
            PlayerPrefs.SetInt("HighScore", highScore);

            // Update the best score text with the new high score
            bestScore.text = "Best"+ highScore.ToString();
        }
    }

    
}
