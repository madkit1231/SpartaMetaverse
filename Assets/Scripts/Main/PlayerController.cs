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

        moveInput.x = Input.GetAxisRaw("Horizontal"); // A/D 또는 ←/→
        moveInput.y = Input.GetAxisRaw("Vertical");   // W/S 또는 ↑/↓
        moveInput = moveInput.normalized; //대각선 속도

        if (animationHandler != null) // 이동 애니메이션 처리
        {
            animationHandler.Move(moveInput);
        }


        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //마우스 현재 위치를 월드 좌표로 변경
        Vector2 characterPos = transform.position; // Vector2 로 변환.

        float xDifference = mousePos.x - characterPos.x; //마우스의 위치가 캐릭터보다 왼쪽인지 오른쪽 인지 확인

        if (xDifference < 0)
            spriteRenderer.flipX = true;   // 왼쪽
        else
            spriteRenderer.flipX = false;  // 오른쪽
    }

    private void FixedUpdate()
    {
        // Rigidbody2D를 통해 이동
        _rigidbody.velocity = moveInput * moveSpeed;
    }


}
