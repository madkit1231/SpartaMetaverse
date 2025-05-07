using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExitButton : MonoBehaviour
{
    public void OnClickExit()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ReturnToMainScene();
        }
        else
        {
            Debug.LogWarning("GameManager.Instance is null! 종료 불가능.");
        }
    }
}
