using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimasiPengendara : MonoBehaviour
{

    public Transform[] IKPoints; 

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnAnimatorIK(int layerIndex)
    {
        animator.SetIKPosition(AvatarIKGoal.RightHand, IKPoints[2].position);
        animator.SetIKRotation(AvatarIKGoal.RightHand, IKPoints[2].rotation);
        animator.SetIKHintPosition(AvatarIKHint.RightElbow, IKPoints[3].position);

        animator.SetIKPosition(AvatarIKGoal.LeftHand, IKPoints[0].position);
        animator.SetIKRotation(AvatarIKGoal.LeftHand, IKPoints[0].rotation);
        animator.SetIKHintPosition(AvatarIKHint.LeftElbow, IKPoints[1].position);

        animator.SetIKPosition(AvatarIKGoal.RightFoot, IKPoints[4].position);
        animator.SetIKRotation(AvatarIKGoal.RightFoot, IKPoints[4].rotation);

        animator.SetIKPosition(AvatarIKGoal.LeftFoot, IKPoints[5].position);
        animator.SetIKRotation(AvatarIKGoal.LeftFoot, IKPoints[5].rotation);


        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 2.0f);
        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 2.0f);

        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 2.0f);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 2.0f);

        animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 2.0f);
        animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 2.0f);

        animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 2.0f);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 2.0f);
    }
}
