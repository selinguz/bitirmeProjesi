using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Button startButton;
    public GameObject panel;
    public GameObject pausePanel;
    private TextMeshProUGUI lblScore;

    private void Start()
    {
        if (GameObject.Find("Score") != null)
        {
            lblScore = GameObject.Find("Score").gameObject.GetComponent<TextMeshProUGUI>();
            lblScore.text = "En İyi Süre : " + getHighScore() + " sn.";
        }
    }

    public int getHighScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }


    public void NewGame()
    {
        SceneManager.LoadScene("FirstScene");
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void HowToPlay()
    {
        panel.SetActive(true);
    }

    public void ReturnToCanvas()
    {
        panel.SetActive(false);
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
