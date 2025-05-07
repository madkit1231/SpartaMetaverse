using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string returnSceneName = "MainScene";

    private static GameManager gameManager;

    public static GameManager Instance
    {
        get { return gameManager; }
    }

    private int currentScore = 0;
    private int bestScore = 0;

    private UIManager uiManager;

    public UIManager UIManager => uiManager;

    private void Awake()
    {
        //중복방지
        if (gameManager == null)
        {
            gameManager = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        LoadBestScore();
    }

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();

        if (uiManager != null)
        {
            uiManager.UpdateScore(currentScore);
            uiManager.UpdateBestScore(bestScore);
        }
    }

    public void AddScore(int score)
    {
        currentScore += score;
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            SaveBestScore();
        }

        if (uiManager != null)
        {
            uiManager.UpdateScore(currentScore);
            uiManager.UpdateBestScore(bestScore);
        }

        Debug.Log("Score: " + currentScore + " / Best: " + bestScore);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        if (uiManager != null)
            uiManager.SetRestart();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMainScene()
    {
        SceneManager.LoadScene(returnSceneName);
    }

    public int GetScore()
    {
        return currentScore;
    }

    public int GetBestScore()
    {
        return bestScore;
    }

    private void SaveBestScore()
    {
        PlayerPrefs.SetInt("BestScore", bestScore);
        PlayerPrefs.Save();
    }

    private void LoadBestScore()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    public void EndMiniGame(bool isSuccess) //미니게임 종료후 출력 될 UI
    {
        string resultMessage = $"당신의 점수는!! {currentScore} 점 \n\n5초후 마을로 돌아갑니다. \n\n 게임을 재시작 하려면 화면을 눌러주세요.";



        if (uiManager != null)
        {
            uiManager.ShowResult(resultMessage);
        }

        // 5초 뒤 맵으로 복귀
        StartCoroutine(ReturnToMainAfterDelay(5f));

    }

    private IEnumerator ReturnToMainAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ReturnToMainScene();
    }
}
