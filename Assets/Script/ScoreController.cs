using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    int score;
    public Text scoreText,scoreText2;

    public Text highScore;

    private void Start()
    {
        score = 0;

        if (scoreText != null) 
        InvokeRepeating("ScoreAdd", 0, 1);

        if(highScore != null)
        {
            var HS = PlayerPrefs.GetInt("HighScore", 0);
            highScore.text = "High Score " + HS;
        }
    }

    void ScoreAdd()
    {
        score = score + 10;
        scoreText.text = "Score " + score;

    }

    public void ScoreUp(int value)
    {
        score = score + value;
        scoreText.text = "Score " + score;
    }

    public void GameOver()
    {
        CancelInvoke("ScoreAdd");

        scoreText2.text = "Score " + score;
        var HS = PlayerPrefs.GetInt("HighScore", 0);
        if (HS <= score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        HS = PlayerPrefs.GetInt("HighScore", 0);
        highScore.text = "High Score " + HS;

        }
    }

