using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsMovig = Animator.StringToHash("IsMove");

    protected Animator animator;

    protected virtual void Awake()
    { 
        animator = GetComponentInChildren<Animator>();
    }

    public void Move(Vector2 obj)
    {
        animator.SetBool(IsMovig, obj.magnitude > 0.5f);
    }
}
