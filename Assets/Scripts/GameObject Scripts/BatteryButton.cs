using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryButton : MonoBehaviour
{
   // private bool batteryCollided = false;
    [SerializeField] Animator animator;

   /* private void Update()
    {
        if (batteryCollided)
        {
            Debug.Log("Battery found!");
        }
        if(!batteryCollided)
        {
            Debug.Log("Battery not found!");
        }   
    } */

    private void OnCollisionExit(Collision collision)
    {
        animator.SetTrigger("Open");
    }


   /* private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Battery"))
        {
            batteryCollided = true;
        }
    }*/
}
