using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D _rigidbody;
    private Vector2 moveInput;
    private SpriteRenderer spriteRenderer;

    protected AnimationHandler animationHandler;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        animationHandler = GetComponent<AnimationHandler>();
    }

    private void Update()
    {

        moveInput.x = Input.GetAxisRaw("Horizontal"); // A/D �Ǵ� ��/��
        moveInput.y = Input.GetAxisRaw("Vertical");   // W/S �Ǵ� ��/��
        moveInput = moveInput.normalized; //�밢�� �ӵ�

        if (animationHandler != null) // �̵� �ִϸ��̼� ó��
        {
            animationHandler.Move(moveInput);
        }


        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //���콺 ���� ��ġ�� ���� ��ǥ�� ����
        Vector2 characterPos = transform.position; // Vector2 �� ��ȯ.

        float xDifference = mousePos.x - characterPos.x; //���콺�� ��ġ�� ĳ���ͺ��� �������� ������ ���� Ȯ��

        if (xDifference < 0)
            spriteRenderer.flipX = true;   // ����
        else
            spriteRenderer.flipX = false;  // ������
    }

    private void FixedUpdate()
    {
        // Rigidbody2D�� ���� �̵�
        _rigidbody.velocity = moveInput * moveSpeed;
    }


}
