using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameStarted;
    private int score=0;
    public Text scoreText;
    public Text highScoreText;
    
    private void Awake()
    {
        highScoreText.text = "High Score: " + GetHighScore().ToString();
    }

    public void StartGame()
    {
        isGameStarted = true;
        FindObjectOfType<Road>().StartBuilding();
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }

    public void IncreaseGameScore()
    {
        score++;
        scoreText.text = score.ToString();

        if(score > GetHighScore())
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = "High Score: " + score.ToString();
        }
    }

    public int getScoreCount()
    {
        return score;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }

    private int GetHighScore()
    {
        int i = PlayerPrefs.GetInt("HighScore");
        return i;
    }
}
