using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;         // 따라갈 대상
    public float smoothTime = 0.25f; // 카메라가 따라가는 시간
    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        if (target != null)
        {
            // 목표 위치 (z 값은 카메라 원래 위치 유지)
            Vector3 targetPosition = target.position;
            targetPosition.z = transform.position.z;

            // 부드럽게 이동
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
