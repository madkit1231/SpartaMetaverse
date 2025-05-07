using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI resultText;

    public void Start()
    {
        if (restartText == null)
        {
            Debug.LogError("restart text is null");
        }

        if (scoreText == null)
        {
            Debug.LogError("scoreText is null");
            return;
        }
        if (bestScoreText == null)
        {
            Debug.LogError("bestScoreText is null");
        }

        restartText.gameObject.SetActive(false);
        resultText.gameObject.SetActive(false);
    }

    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
    public void UpdateBestScore(int best)
    {
        bestScoreText.text = "최고 점수: " + best.ToString();
    }

    public void ShowResult(string message)
    {
        resultText.text = message;
        resultText.gameObject.SetActive(true);
    }
}
