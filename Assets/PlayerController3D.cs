using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3D : MonoBehaviour
{
    public float speed, turnSpeed;
    static readonly int speedHash = Animator.StringToHash("Speed");
    static readonly int turnSpeedHash = Animator.StringToHash("TurningRate");

    public Animator animator;

    private void Start()
    {
        StartCoroutine(SetAnimatorSpeeds());
    }


    void Update()
    {
        turnSpeed = Input.GetAxis("Horizontal");
        speed = Input.GetAxis("Vertical");
    }

    IEnumerator SetAnimatorSpeeds()
    {
        while (true)
        {
            animator.SetFloat(speedHash, speed);
            animator.SetFloat(turnSpeedHash, turnSpeed);
            yield return new WaitForSeconds(0.1f);
        }
    }
}