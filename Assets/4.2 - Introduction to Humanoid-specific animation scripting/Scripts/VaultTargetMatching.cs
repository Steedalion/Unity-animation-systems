using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaultTargetMatching : MonoBehaviour
{
    public Animator animator;
    public Transform wallHandPosition, footWallPosition;
    public AnimationCurve curve;
    public float takeOffTime = 0.027f;
    public float handDownTime = 0.371f;

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Vault"))
        {
            // MatchTargetWeightMask mask = new MatchTargetWeightMask(Vector3.one, 0f);
            // animator.MatchTarget(wallHandPosition.position, wallHandPosition.rotation, AvatarTarget.LeftHand, mask, takeOffTime, handDownTime);
        }
    }

    private void OnAnimatorIK(int layerIndex)
    {
        AnimatorStateInfo vault = animator.GetCurrentAnimatorStateInfo(0);
        if (vault.IsName("Vault") )
        {
            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, curve.Evaluate(vault.normalizedTime));
            animator.SetIKPosition(AvatarIKGoal.LeftFoot, footWallPosition.position);
            // animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, curve.Evaluate(vault.normalizedTime));
            // animator.SetIKPosition(AvatarIKGoal.RightFoot, footWallPosition.position);
        }
    }
}