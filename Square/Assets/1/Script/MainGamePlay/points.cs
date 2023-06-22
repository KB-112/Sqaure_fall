using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class points : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScore;
    private int highScore;
    private int score;

  //  public GameObject scorehide;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        bestScore.text = highScore.ToString();
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            bestScore.text = highScore.ToString();
          //  PlayerPrefs.Save();
        }
     
    }


    /* public void ScoreHide()
     {
         scorehide.SetActive(false);
     }
 */
}