using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem instance;

    public Text scoreText;
    public int scoreCount;

    public Text highScoreText;
    private int highScore;

    private void Start()
    {
        instance = this;
    }
    void Update()
    {
        if(scoreCount <= highScore)
        {
            highScore = scoreCount;
        }
        highScoreText.text = "Highscore:  " + highScore.ToString();
        scoreText.text = "Score:  " + scoreCount.ToString();
    }

    public void AddScore()
    {
        scoreCount += 10;
    }
}
