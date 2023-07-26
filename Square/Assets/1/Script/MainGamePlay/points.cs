using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class points : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScore;
    private  int highScore;
    [HideInInspector] public  int score;


   public static int totalScore = 0;
    void Start()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        bestScore.text = highScore.ToString();

        if (PlayerPrefs.HasKey("TotalScore"))
        {
            totalScore = PlayerPrefs.GetInt("TotalScore");
            Debug.Log("Total score" + totalScore);
        }


    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();
        SaveTotalScore();
        Debug.Log(totalScore);
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            bestScore.text = highScore.ToString();

        }

    }

  
    public  void SaveTotalScore()
    {if(NewBehaviourScript.doublescore)
        {
            totalScore += 2*score;
        }
        else
        {
            totalScore += score;
        }
           
        PlayerPrefs.SetInt("TotalScore", totalScore);
        PlayerPrefs.Save();  
    }
   

}