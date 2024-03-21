using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public int score;
    public Text scoreText;
    private float timeLimit = 60f;
    public Text timeText;
    public GameObject timeFinishedPanel;
    public GameObject youWinPanel;
    private int totalTrashBins = 0;
    private int trashbinToPick;
    private bool gameIsGoing = true;

    private void Start()
    {
        UpdateScore();
    }

    private void Update()
    {
        if (gameIsGoing)
        {
            timeLimit -= Time.deltaTime;

            if (timeLimit <= 0)
            {
                TimeFinished();
            }

            UpdateTime();
        }
    }

    void UpdateTime()
    {
        timeText.text = "Zaman: " + Mathf.Ceil(timeLimit).ToString();
    }

    void TimeFinished()
    {
        gameIsGoing = false;
        Time.timeScale = 0f;
        timeFinishedPanel.SetActive(true);
    }

    public void IncrementScore(int incrementAmount)
    {
        score += incrementAmount;
        UpdateScore(); 
    }

    void UpdateScore()
    {
        scoreText.text = "Skor: " + score.ToString();
    }

    public void TrashBinPicked()
    {
        totalTrashBins++;
        trashbinToPick = 12;

        if (totalTrashBins >= trashbinToPick)
        {
            gameIsGoing = false;
            Time.timeScale = 0f;
            youWinPanel.SetActive(true);
            int point = 60 - (int)Mathf.Ceil(timeLimit);
            int highestScore = PlayerPrefs.GetInt("HighScore");
            if (point < highestScore)
            {
                PlayerPrefs.SetInt("HighScore", point);
            }
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("SecondScene");
    }

    public void SecondSceneTrashBinPicked()
    {
        totalTrashBins++;
        trashbinToPick = 35;

        if (totalTrashBins >= trashbinToPick)
        {
            gameIsGoing = false;
            Time.timeScale = 0f;
            youWinPanel.SetActive(true);
            int point = 60 - (int)Mathf.Ceil(timeLimit);
            int highestScore = PlayerPrefs.GetInt("HighScore");
            if (point < highestScore)
            {
                PlayerPrefs.SetInt("HighScore", point);
            }
        }
    }
}
