using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAnim : MonoBehaviour
{
    public Animator animator;
    private void OnAnimatorMove()
    {
        transform.position += animator.deltaPosition;
        transform.rotation *= animator.deltaRotation;
    }
}
