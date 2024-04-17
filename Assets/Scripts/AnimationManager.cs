using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator animator;
    int vertical;
    int horizontal;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        vertical = Animator.StringToHash("Vertical");
        horizontal = Animator.StringToHash("Horizontal");
    }

    public void PlayTargetAnimation(string targetAnimation, bool isInteracting)
    {
        animator.SetBool("isInteracting", isInteracting);
        animator.CrossFade(targetAnimation, 0.2f);
    }
    public void UpdateAnimatorValues(float verticalMovement, float horizontalMovement)
    {
        float snappedVertical = verticalMovement < 0 ? -1 : verticalMovement > 0 ? 1 : 0;
        float snappedHorizontal = horizontalMovement < 0 ? -1 : horizontalMovement > 0 ? 1 : 0;

        animator.SetFloat(vertical, verticalMovement, 0.1f, Time.deltaTime);
        animator.SetFloat(horizontal, horizontalMovement, 0.1f, Time.deltaTime);
    }
}
