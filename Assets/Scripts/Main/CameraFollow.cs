using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;         // ���� ���
    public float smoothTime = 0.25f; // ī�޶� ���󰡴� �ð�
    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        if (target != null)
        {
            // ��ǥ ��ġ (z ���� ī�޶� ���� ��ġ ����)
            Vector3 targetPosition = target.position;
            targetPosition.z = transform.position.z;

            // �ε巴�� �̵�
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
