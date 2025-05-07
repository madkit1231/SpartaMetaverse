using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniGametrigger : MonoBehaviour
{
    //�̴ϰ��� ����
    public string message = "�̴ϰ��ӿ� �����Ͻðڽ��ϱ�?";
    public string miniGameSceneName = "MiniGameScene";

    //UI ����
    public Button yesButton;
    public Button noButton;
    public GameObject popupUi;

    //Ʈ���� ����
    public bool oneTimeTrigger = false;
    private bool hasTriggered = false;

    public void Start()
    {
        if (popupUi != null)
        {
            popupUi.SetActive(false); //��Ż�� ���� ���� �˾��� ������.
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasTriggered) return;

        if (other.CompareTag("Player"))
        {
            Debug.Log(message);
            popupUi.SetActive(true); // �˾� UI ����

            yesButton.onClick.RemoveAllListeners();
            noButton.onClick.RemoveAllListeners();

            yesButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(miniGameSceneName);
            });

            noButton.onClick.AddListener(() =>
            {
                popupUi.SetActive(false); // �˾� �ݱ�
            });
            if (oneTimeTrigger)
                hasTriggered = true;
        }
    }
}
