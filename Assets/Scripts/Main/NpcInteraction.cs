using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NpcInteraction : MonoBehaviour
{
    public string npcName = "ô���� ����";
    [TextArea]
    public string dialogue = "Hello";

    private bool isPlayerInRange = false;

    public GameObject dialogueBubbleObject;
    private TextMeshProUGUI dialogueText;


    public void Start()
    {
        if (dialogueBubbleObject != null)
        {
            dialogueText = dialogueBubbleObject.GetComponentInChildren<TextMeshProUGUI>();
            dialogueBubbleObject.SetActive(false); // ���� �� ��ǳ�� ����
        }
    }
    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (dialogueBubbleObject != null)
            {
                bool isActive = dialogueBubbleObject.activeSelf;
                dialogueBubbleObject.SetActive(!isActive);

                if (!isActive)
                {
                    dialogueText.text = dialogue;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            if (dialogueBubbleObject != null)
            {
                dialogueBubbleObject.SetActive(false); // ���� ����� ��ǳ�� ����
            }
        }
    }
}
