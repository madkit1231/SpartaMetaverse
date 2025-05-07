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
        //�ߺ�����
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

    public void EndMiniGame(bool isSuccess) //�̴ϰ��� ������ ��� �� UI
    {
        string resultMessage = $"����� ������!! {currentScore} �� \n\n5���� ������ ���ư��ϴ�. \n\n ������ ����� �Ϸ��� ȭ���� �����ּ���.";



        if (uiManager != null)
        {
            uiManager.ShowResult(resultMessage);
        }

        // 5�� �� ������ ����
        StartCoroutine(ReturnToMainAfterDelay(5f));

    }

    private IEnumerator ReturnToMainAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ReturnToMainScene();
    }
}
