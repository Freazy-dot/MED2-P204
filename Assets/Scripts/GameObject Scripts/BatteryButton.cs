using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryButton : MonoBehaviour
{
    [SerializeField] Animator animator;

    /// <summary>
    /// once battery is removed from the button it triggers the colour code animation
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit(Collision collision)
    {
        animator.SetTrigger("Open");
    }
}
