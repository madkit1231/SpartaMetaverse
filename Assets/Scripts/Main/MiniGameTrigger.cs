using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniGametrigger : MonoBehaviour
{
    //미니게임 설정
    public string message = "미니게임에 입장하시겠습니까?";
    public string miniGameSceneName = "MiniGameScene";

    //UI 구성
    public Button yesButton;
    public Button noButton;
    public GameObject popupUi;

    //트리거 설정
    public bool oneTimeTrigger = false;
    private bool hasTriggered = false;

    public void Start()
    {
        if (popupUi != null)
        {
            popupUi.SetActive(false); //포탈로 들어가기 전에 팝업을 꺼놓기.
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasTriggered) return;

        if (other.CompareTag("Player"))
        {
            Debug.Log(message);
            popupUi.SetActive(true); // 팝업 UI 띄우기

            yesButton.onClick.RemoveAllListeners();
            noButton.onClick.RemoveAllListeners();

            yesButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(miniGameSceneName);
            });

            noButton.onClick.AddListener(() =>
            {
                popupUi.SetActive(false); // 팝업 닫기
            });
            if (oneTimeTrigger)
                hasTriggered = true;
        }
    }
}
