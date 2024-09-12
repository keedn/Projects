using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    public Text highScoreText;
    public Text levelText;
    public Text linesClearedText;
    int score;
    int highScore = 0;
    private int level = 1;
    private int linesCleared = 0;
    private static readonly int[] scoreTable = { 0, 40, 100, 300, 1200 };

    void Awake()// means that at very start of the game this function will be called 
    {
        instance = this;
    }
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        scoreText.text = "SCORE: " + score.ToString() ; 
        highScoreText.text = "HIGH SCORE: " + highScore.ToString();
    }

    // Update is called once per frame
  public void AddScore(int lineCount)
  {
    Debug.Log("addScore called | LineCount = " + lineCount );
     

    if (lineCount < 1 || lineCount > 4)
            return;

        score += scoreTable[lineCount] * level;
        Debug.Log("score = " + score);
        linesCleared += lineCount;

        if (highScore < score)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", score);
        }
        
        UpdateLevel();
        UpdateUI();
    
  }

  private void UpdateLevel()
    {
        level = (linesCleared / 10) + 1;
    }

  private void UpdateUI()
    {
        Debug.Log("| linesCleared = " + linesCleared);
        Debug.Log("| level = " + level);
        Debug.Log("| score = " + score);
       
        scoreText.text = "SCORE: " + score.ToString();
        highScoreText.text = "HIGH SCORE: " + highScore.ToString();
        levelText.text = "LEVEL: " + level.ToString();
        linesClearedText.text = "LINES CLEARED: " + linesCleared.ToString();
    }
}
